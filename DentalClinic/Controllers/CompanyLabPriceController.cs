using DentalClinic.DTOs.CompanyLabPricesDTO;
using DentalClinic.Services.CompanyLabPricesService;
using DentalClinic.Services.CompanySettingService;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLabPriceController : Controller
    {
        private readonly ICompanyLabPricesService _price;
        public CompanyLabPriceController(ICompanyLabPricesService price)
        {
            _price = price;
        }

        [HttpPost("SetPrices")]
        public async Task<ActionResult> AddCompanyLabPriceServices(AddCompanyLabPricesDTO DTO)
        {
            try
            {
                return Ok(await _price.AddCompanyLabPrices(DTO));

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Patient/Dentist/ActionBy Not Found
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Appointment start time in the past
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // Dentist or ActionBy already has an appointment
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetPrices")]
        public async Task<ActionResult> GetPrices()
        {
            try
            {
                return Ok(await _price.GetLabPrices());

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Patient/Dentist/ActionBy Not Found
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Appointment start time in the past
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // Dentist or ActionBy already has an appointment
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
