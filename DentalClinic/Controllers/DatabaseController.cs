using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.Models;
using DentalClinic.Services.AppointmentService;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        private readonly IDatabaseService _databaseService;
        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        [HttpPost("restore")]
        public async Task<ActionResult> Restore(DatabaseDTO dto)
        {
            try
            {
                return Ok(await _databaseService.RestoreZip(dto.Name));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }

        [HttpPost("backup")]
        public async Task<ActionResult> Backup(DatabaseDTO dto)
        {
            return Ok(await _databaseService.Backup(dto.Name));
        }

        [HttpGet("backup/download/{name}")]
        public async Task<ActionResult> DownloadBackup(string name)
        {
            return await _databaseService.DownloadBackup(name, this);
        }

        [HttpPost("backup/upload")]
        public async Task<ActionResult> UploadBackup(IFormFile file)
        {
            try
            {
                return Ok(await _databaseService.SaveBackup(file));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }

        [HttpPost("backup/delete")]
        public async Task<ActionResult> DeleteBackup(BackupDTO dto)
        {
            return Ok(await _databaseService.RemoveBackup(dto.Name));
        }

        [HttpGet("backup")]
        public async Task<ActionResult> GetBackups()
        {
            return Ok(await _databaseService.GetBackups());
        }
    }
}
