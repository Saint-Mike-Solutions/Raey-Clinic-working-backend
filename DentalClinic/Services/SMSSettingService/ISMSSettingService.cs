using DentalClinic.DTOs.SMSSettingDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.SMSSettingService
{
    public interface ISMSSettingService
    {
        Task<SMSSetting> AddSMSSetting(SMSSettingAddDTO SMSDto);
        Task<SMSSetting> GetSMSSettings();
        Task<SMSSetting> UpdateSMSSetting(SMSSettingUpdateDTO DTO);
    }
}