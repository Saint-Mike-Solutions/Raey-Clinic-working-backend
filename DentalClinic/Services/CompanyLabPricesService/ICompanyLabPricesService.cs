using DentalClinic.DTOs.CompanyLabPricesDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.CompanyLabPricesService
{
    public interface ICompanyLabPricesService
    {
        Task<CompanyLabPrices> AddCompanyLabPrices(AddCompanyLabPricesDTO DTO);
        Task<CompanyLabPrices> GetLabPrices();
    }
}