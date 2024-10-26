using DentalClinic.DTOs.SettingsDTO;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Services.AppointmentService
{
    public interface IDatabaseService
    {
        Task<string> Backup(string message = "");
        Task CreateDirectoryIfNotExists(string path);
        Task<FileContentResult> DownloadBackup(string name, ControllerBase controller);
        Task<string> GetBackupFilePath(string name);
        Task<List<BackupDTO>> GetBackups();
        Task<string> RemoveBackup(string name);
        Task<string> Restore(string name, bool temp = false);
        Task<string> RestoreZip(string name);
        Task<string> SaveBackup(IFormFile file);
    }
}