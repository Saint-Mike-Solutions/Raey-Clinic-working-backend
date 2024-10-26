using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.LogInDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public AuthenticationController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody]LoginDTO login)
        {
            try
            {
                return Ok(await _employeeService.Login(login));
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
