using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using DentalClinic.Services.MedicalRecordService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _recordService;
        public MedicalRecordController(IMedicalRecordService recordService)
        {
            _recordService = recordService;
        }
        //Add a new Employee 
        [HttpPost]
        public async Task<ActionResult> AddMedicalRecord(AddMedicalRecordDTO medicalRecordDTO)
        {


            try
            {
                
                return Ok(await _recordService.AddMedicalRecord(medicalRecordDTO));
            }
            //return Ok(await _employeeService.AddEmployee(employeeDTO));            }
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
            catch (DbUpdateException ex)
            {
                // Handle database update related exceptions specifically
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Database update error: " + ex.InnerException?.Message });
            }
            catch (NullReferenceException ex)
            {
                // Handle null reference exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Null reference error: " + ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception details for further analysis
                // Use your logging framework here
                Console.WriteLine(ex); // or a logger

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "An unexpected error occurred. Please try again later." });
            }
        }
        [HttpGet("GetMedicalRecordForPatient")]
        public async Task<ActionResult> GetMedicalRecordForPatient(int patientID)
        {
            try
            {
                return Ok(await _recordService.GetMedicalRecordById(patientID));
            }
            //return Ok(await _employeeService.AddEmployee(employeeDTO));            }
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
            catch (DbUpdateException ex)
            {
                // Handle database update related exceptions specifically
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Database update error: " + ex.InnerException?.Message });
            }
            catch (NullReferenceException ex)
            {
                // Handle null reference exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Null reference error: " + ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception details for further analysis
                // Use your logging framework here
                Console.WriteLine(ex); // or a logger

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "An unexpected error occurred. Please try again later." });
            }

        }
        [HttpPut]
        public async Task<ActionResult> UpdateMedicalRecord(UpdateMedicalRecordDTO DTO)
        {

            try
            {
                return Ok(await _recordService.UpdateMedicalRecord(DTO));
            }
            //return Ok(await _employeeService.AddEmployee(employeeDTO));            }
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
            catch (DbUpdateException ex)
            {
                // Handle database update related exceptions specifically
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Database update error: " + ex.InnerException?.Message });
            }
            catch (NullReferenceException ex)
            {
                // Handle null reference exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Null reference error: " + ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception details for further analysis
                // Use your logging framework here
                Console.WriteLine(ex); // or a logger

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "An unexpected error occurred. Please try again later." });
            }

        }
        [HttpGet("GetMedicalRecords")]
        public async Task<ActionResult> GetMedicalRecords()
        {

            try
            {
                return Ok(await _recordService.GetAllMedicalRecords());
            }
            //return Ok(await _employeeService.AddEmployee(employeeDTO));

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
            catch (DbUpdateException ex)
            {
                // Handle database update related exceptions specifically
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Database update error: " + ex.InnerException?.Message });
            }
            catch (NullReferenceException ex)
            {
                // Handle null reference exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Null reference error: " + ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception details for further analysis
                // Use your logging framework here
                Console.WriteLine(ex); // or a logger

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "An unexpected error occurred. Please try again later." });
            }

        }
        private ActionResult ParseException(Exception ex)
        {
            throw new NotImplementedException();
        }

    }
}
