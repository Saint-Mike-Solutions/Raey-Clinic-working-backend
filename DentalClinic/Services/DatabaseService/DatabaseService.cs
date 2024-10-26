using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using MimeTypes;
using System.IO.Compression;
using DentalClinic.Services.AppointmentService;
using System;
using DentalClinic.DTOs.SettingsDTO;

namespace DentalClinic.Services.AppointmentService
{
    public class DatabaseService : IDatabaseService
    {
        private const string VERSION_FILE = "version.meselal";
        private const string SYSTEM_FILE = "system.meselal";
        private const string TEMP_FILE_PATH = "temp";
        private readonly IConfigurationRoot _config;
        private string _path;
        public DatabaseService(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _path = Path.Combine(env.ContentRootPath, "DatabaseBackups");
        }

        public async Task<string> RestoreZip(string name)
        {
            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];
            string system = _config.GetSection("Backup")["System"];
            string version = _config.GetSection("Backup")["Version"];

            SqlConnection con = new SqlConnection(connectionString);
            string database = con.Database.ToString();
            string backupLocation = await GetBackupLocation(con);

            var tempLocation = Path.Combine(backupLocation, TEMP_FILE_PATH);
            await CreateDirectoryIfNotExists(tempLocation);

            backupLocation = Path.Combine(backupLocation, name);

            if (!File.Exists(backupLocation))
                throw new KeyNotFoundException("Backup Not Found");

            ZipFile.ExtractToDirectory(backupLocation, tempLocation, true);

            var zip = ZipFile.OpenRead(backupLocation);

            string backupFileName = zip.Entries.FirstOrDefault(x => Path.GetExtension(x.Name) == ".bak")?.Name;
            var systemFile = zip.Entries.FirstOrDefault(x => x.Name == SYSTEM_FILE);
            var versionFile = zip.Entries.FirstOrDefault(x => x.Name == VERSION_FILE);

            if (systemFile == null || versionFile == null || backupFileName == null || backupFileName == "")
                throw new InvalidOperationException("Backup is Not Valid");

            using (var entryStream = systemFile.Open())
            using (var streamReader = new StreamReader(entryStream))
            {
                if (streamReader.ReadToEnd().Trim() != system.Trim())
                    throw new InvalidOperationException("Backup System is Not Valid");
            }

            using (var entryStream = versionFile.Open())
            using (var streamReader = new StreamReader(entryStream))
            {
                if (streamReader.ReadToEnd().Trim() != version.Trim())
                    throw new InvalidOperationException("Backup Version is Not Valid");
            }

            await Restore(backupFileName, true);

            Directory.Delete(tempLocation, true);

            return "Database Restored Successfully";
        }

        public async Task<string> Restore(string name, bool temp = false)
        {
            await Backup("Automatic Backup Before Restore");

            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];

            SqlConnection con = new SqlConnection(connectionString);
            string database = con.Database.ToString();
            string backupLocation = await GetBackupLocation(con);

            if (temp)
                backupLocation = Path.Combine(backupLocation, TEMP_FILE_PATH);

            backupLocation = Path.Combine(backupLocation, name);

            if (!File.Exists(backupLocation))
                throw new KeyNotFoundException("Backup Not Found");

            con.Open();

            try
            {
                string query1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();

                string query2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + backupLocation + "' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Restore Failed", ex);
            }
            finally
            {
                string query3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();
            }

            con.Close();

            return "Database Restored Successfully";
        }

        //public async Task ScheduledBackup()
        //{
        //    const string DAYS_SETTING_KEY = "database-backup-days";
        //    const string LAST_SETTING_KEY = "last-database-backup";

        //    int backupDays = 0;
        //    DateTime lastBackup = DateTime.Now;

        //    try
        //    {

        //        var backupDaysSetting = await _settingService.Get(DAYS_SETTING_KEY);
        //        backupDays = Int32.Parse(backupDaysSetting.Value);
        //    }
        //    catch
        //    {
        //        return;
        //    }

        //    if (backupDays == 0)
        //        return;

        //    Setting? LastBackupSetting = null;

        //    try
        //    {
        //        LastBackupSetting = await _settingService.Get(LAST_SETTING_KEY);
        //    }
        //    catch
        //    {
        //        await _settingService.Add(new SettingDTO
        //        {
        //            Key = LAST_SETTING_KEY,
        //            Value = DateTime.Now.ToString()
        //        });
        //    }

        //    if (LastBackupSetting != null)
        //        lastBackup = DateTime.Parse(LastBackupSetting.Value);

        //    var nextBackup = lastBackup.AddDays(backupDays).AddMinutes(-10);

        //    if (nextBackup <= DateTime.Now)
        //    {
        //        await Backup("Automatic Scheduled Backup");

        //        await _settingService.Update(new SettingDTO
        //        {
        //            Key = LAST_SETTING_KEY,
        //            Value = DateTime.Now.ToString()
        //        });
        //    }

        //    return;

        //}


        public async Task<string> Backup(string message = "")
        {
            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];
            string system = _config.GetSection("Backup")["System"];
            string version = _config.GetSection("Backup")["Version"];

            SqlConnection con = new SqlConnection(connectionString);
            string database = con.Database.ToString();
            string backupLocation = await GetBackupLocation(con);

            var backupFile = Path.Combine(backupLocation, message + " [Backup-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + "].bak");
            string query = "BACKUP DATABASE [" + database + "] TO DISK='" + backupFile + "'";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            var zip = ZipFile.Open(Path.Combine(backupFile + ".zip"), ZipArchiveMode.Create);
            zip.CreateEntryFromFile(backupFile, Path.GetFileName(backupFile), CompressionLevel.Optimal);

            var versionFile = zip.CreateEntry(VERSION_FILE);
            using (var entryStream = versionFile.Open())
            using (var streamWriter = new StreamWriter(entryStream))
            {
                streamWriter.Write(version);
            }

            var systemFile = zip.CreateEntry(SYSTEM_FILE);
            using (var entryStream = systemFile.Open())
            using (var streamWriter = new StreamWriter(entryStream))
            {
                streamWriter.Write(system);
            }

            zip.Dispose();

            File.Delete(backupFile);

            return "Backup Successfully Created";
        }

        public async Task<List<BackupDTO>> GetBackups()
        {
            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];

            SqlConnection con = new SqlConnection(connectionString);
            string backupLocation = await GetBackupLocation(con);

            return Directory.GetFiles(backupLocation, "*.zip")
                .Select(x =>
                {
                    string name = Path.GetFileName(x);

                    return new BackupDTO()
                    {
                        Name = name,
                        Label = name.Split("[").ElementAt(0),
                        Date = new FileInfo(x).CreationTime,
                    };
                })
                .OrderByDescending(d => d.Date)
                .ToList();
        }

        public async Task<string> SaveBackup(IFormFile file)
        {
            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];

            SqlConnection con = new SqlConnection(connectionString);
            string backupLocation = await GetBackupLocation(con);

            string savePath = Path.Combine(backupLocation, "(Uploaded) " + file.FileName);

            if (File.Exists(savePath))
                throw new InvalidOperationException("Backup file already exists.");

            using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                file.CopyTo(fileStream);

            return "File Saved";
        }

        public async Task<FileContentResult> DownloadBackup(string name, ControllerBase controller)
        {
            string filePath = await GetBackupFilePath(name);

            string fileName = Path.GetFileName(filePath);

            var file = File.ReadAllBytes(filePath);

            return controller.File(file, MimeTypeMap.GetMimeType(Path.GetExtension(filePath)), fileName);

        }

        public async Task<string> RemoveBackup(string name)
        {
            string file = await GetBackupFilePath(name);

            File.Delete(file);

            return "Backup Removed Successfully";
        }

        public async Task<string> GetBackupFilePath(string name)
        {
            string connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"];

            SqlConnection con = new SqlConnection(connectionString);
            string backupLocation = await GetBackupLocation(con);

            string file = Path.Combine(backupLocation, name);

            if (!File.Exists(file))
                throw new InvalidOperationException("Backup Not Found.");

            return file;
        }

        private async Task<string> GetBackupLocation(SqlConnection con)
        {
            string backupLocation = _path;
            //string backupLocation = _config.GetSection("Backup")["Directory"];
            string database = con.Database.ToString();

            backupLocation = Path.Combine(backupLocation, database);
            await CreateDirectoryIfNotExists(backupLocation);

            return backupLocation;
        }


        public async Task CreateDirectoryIfNotExists(string path)
        {
            bool exists = Directory.Exists(path);

            if (!exists)
                Directory.CreateDirectory(path);
        }
    }
}