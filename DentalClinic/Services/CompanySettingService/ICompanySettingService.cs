using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.CompanySettingService
{
    public interface ICompanySettingService
    {
        Task<CompanySetting> AddCompanySetting(AddCompanySettingsDTO add);
        Task<CompanySetting> GetCompanySetting();
        Task<CompanySetting> UpdateComapnySetting(UpdateCompanySettingDTO update);
    }
}