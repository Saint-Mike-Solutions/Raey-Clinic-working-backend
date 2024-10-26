using DentalClinic.DTOs.LaboratoryRequestListDTO;
using DentalClinic.DTOs.LaboratoryRequestsDTO;
using DentalClinic.Models;
using DentalClinic.Services.LaboratoryRequestListService;
using DentalClinic.Services.LaboratoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryRequestListController : Controller
    {
        private readonly ILaboratoryRequestListService _laboratoryRequestListService;
        public LaboratoryRequestListController(ILaboratoryRequestListService laboratoryRequestListService)
        {
            _laboratoryRequestListService = laboratoryRequestListService;
        }
        [HttpPost("AddLabReqList")]
        public async Task<ActionResult> AddLaboratoryReport([FromBody] AddLaboratoryRequestListDTO DTO)
        {
            if (DTO == null)
            {
                return BadRequest(new ErrorResponse { Message = "Prescription data cannot be null." });
            }

            try
            {
                var result = await _laboratoryRequestListService.AddLaboratoryRequestList(DTO);
                return Ok(result);
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

        [HttpPut("UpdateLabReqList")]
        public async Task<ActionResult> UpdateLaboratoryReport([FromBody] UpdateLaboratoryRequestListDTO DTO)
        {
            if (DTO == null)
            {
                return BadRequest(new ErrorResponse { Message = "Prescription data cannot be null." });
            }

            try
            {
                var result = await _laboratoryRequestListService.UpdateLabRequestList(DTO);
                return Ok(result);
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


        [HttpGet("GetAllLabReq")]
        public async Task<ActionResult> GetAllLabReq()
        {

            try
            {
                var result = await _laboratoryRequestListService.GetAllLaboratoryRequestLists();
                return Ok(result);
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

        [HttpGet("GetSpecificLabReqList")]
        public async Task<ActionResult> GetSpecificLabReq(int id)
        {

            try
            {
                var result = await _laboratoryRequestListService.GetLabReqListById(id);
                return Ok(result);
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

        [HttpDelete("DeleteLabReqList")]
        public async Task<ActionResult> DeleteLabRequestList(int id)
        {

            try
            {
                var result = await _laboratoryRequestListService.DeleteLabRequestList(id);
                return Ok(result);
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
    }
}
