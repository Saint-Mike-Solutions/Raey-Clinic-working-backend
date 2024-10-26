using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using DentalClinic.Services.MobileBankingService;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileBankingController : Controller
    {
        private readonly IMobileBankingService _mobileBankingService;
        public MobileBankingController(IMobileBankingService mobileBankingService)
        {
            _mobileBankingService = mobileBankingService;
        }
        //Add a new Employee 
        [HttpPost]
        public async Task<ActionResult> AddMobileBanking(AddMobileBankingDTO DTO)
        {
            return Ok(await _mobileBankingService.AddMobileBanking(DTO));

            try
            {

                return Ok(await _mobileBankingService.AddMobileBanking(DTO));
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
        [HttpPut]
        public async Task<ActionResult> UpdateMobileBanking(UpdateMobileBankingDTO DTO)
        {
            try
            {

                return Ok(await _mobileBankingService.UpdateMobileBanking(DTO));
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
        [HttpGet]
        public async Task<ActionResult> GetMobileBankingInfo()
        {
            try
            {

                return Ok(await _mobileBankingService.GetAllMobileBankings());
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
        [HttpDelete]
        public async Task<ActionResult> DeleteMobileBanking(RemoveMobileBankingDTO DTO)
        {
            try
            {

                return Ok(await _mobileBankingService.RemoveMobileBanking(DTO));
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
    }
}
