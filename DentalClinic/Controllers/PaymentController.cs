using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.DTOs.PaymentDTO;
using DentalClinic.Models;
using DentalClinic.Services.AppointmentService;
using DentalClinic.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _patientService;
        public PaymentController(IPaymentService patientService)
        {
            _patientService = patientService;
        }
        //add a new employee
        [HttpPost]
        public async Task<ActionResult> MakePayment(MakePaymentMedRecDTO DTO)
        {
            try
            {
                return Ok(await _patientService.AddPaymentfromMedicalRecord(DTO));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse
                {
                    Message = "The specified key was not found. Please check your input.",
                    Details = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Invalid argument provided. Please check your request.",
                    Details = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse
                {
                    Message = "The requested operation is not valid in the current state.",
                    Details = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    Message = "An unexpected error occurred on the server.",
                    Details = GetFullExceptionMessage(ex)
                });
            }


        }
        private string GetFullExceptionMessage(Exception ex)
        {
            var message = ex.Message;
            var inner = ex.InnerException;

            while (inner != null)
            {
                message += " --> " + inner.Message;
                inner = inner.InnerException;
            }

            return message;
        }

        [HttpGet]
        public async Task<ActionResult> displayID(int PatientID)
        {
            try
            {
                return Ok(await _patientService.GetMedicalRecordsforPayment(PatientID));
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
        [HttpGet("PaymentLogForPatient")]
        public async Task<ActionResult> PaymentLogForPatient(int patientID)
        {
            try
            {
                return Ok(await _patientService.PaymentLogForPatient(patientID));
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
        [HttpGet("PaymentHistory")]
        public async Task<ActionResult> PaymentHistory(int paymentId)
        {
            //return Ok(await _patientService.PaymentHistoryDetails(paymentId));

            try
            {
                return Ok(await _patientService.PaymentHistoryDetails(paymentId));
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
        [HttpGet("PaymentLogForAll")]
        public async Task<ActionResult> PaymentLogForAll()
        {
            try
            {
                return Ok(await _patientService.PaymentLogForAll());
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
