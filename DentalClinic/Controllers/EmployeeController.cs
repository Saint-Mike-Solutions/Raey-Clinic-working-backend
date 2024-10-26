using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.LogInDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //Add a new Employee 
        [HttpPost]
        public async Task<ActionResult> AddEmployee(AddEmployeeDTO employeeDTO)
        {
            try
            {
                return Ok(await _employeeService.AddEmployee(employeeDTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse
                {
                    Message = "The specified key was not found.",
                    Details = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Invalid arguments were provided.",
                    Details = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse
                {
                    Message = "Operation cannot be completed due to a conflict.",
                    Details = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    Message = "An internal server error occurred.",
                    Details = ex.Message
                });
            }

        }
        //Restore Password
        [HttpPut("RestorePassword")]
        public async Task<ActionResult> RestorePassword([FromBody]RestorePasswordDTO DTO)
        {
            try
            {
                return Ok(await _employeeService.RestorePassword(DTO));
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
        //Get total Number of Employees 
        [HttpGet("total")]
        public async Task<ActionResult> GetTotalEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetTotalEmployeeCountAsync());
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

        //Get all the employees 
        [HttpGet("GetAllEMployee")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok( await _employeeService.GetAllEmployee());
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
        [HttpGet("GetAllEMployeeWhoAreHired")]
        public async Task<ActionResult> GetWorkingEmployee()
        {
            try
            {
                return Ok(await _employeeService.GetAllHiredEmployee());
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
        //Get a specific employee by ID
        [HttpGet("GetSpecificEmployee")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            try
            {
                return Ok(await _employeeService.GetEmployeeById(id));
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

        [HttpGet("GetMedicalCertificatesAdministered")]

        public async Task<ActionResult> GetMedicalCertificates()
        {
            try
            {
                return Ok(await _employeeService.GetMedicalCertificates());

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

        //Update employee information


        //Delete an employee
        [HttpDelete("Employee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                return Ok(await _employeeService.DeleteEmployee(id));

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
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeDTO employeeDTO)
        {
            try
            {
                return Ok(await _employeeService.UpdateEmployee(employeeDTO));

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

        [HttpPut("Change Password")]
        public async Task<ActionResult> changePassword(ChangePasswordDTO pwDTO)
        {
            try
            {
                return Ok(await _employeeService.ChangePassword(pwDTO));

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



        private ActionResult ParseException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
