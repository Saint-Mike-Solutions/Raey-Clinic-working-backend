using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.RoleDTO;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.DTOs.SMSSettingDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.SMSSettingService
{
    public class SMSSettingService : ISMSSettingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SMSSettingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SMSSetting> AddSMSSetting(SMSSettingAddDTO SMSDto)
        {
            var num = await _context.SMSSettings.CountAsync();
            if (num >= 1)
            {
                throw new Exception("SMS setting is already set, update the existing setting.");
            }
            var SMS = _mapper.Map<SMSSetting>(SMSDto);
            _context.SMSSettings.Add(SMS);
            await _context.SaveChangesAsync();
            return SMS;
        }
        public async Task<SMSSetting> UpdateSMSSetting(SMSSettingUpdateDTO DTO)
        {
            var compSetting = await _context.SMSSettings
                                    //.OrderByDescending(u => u.UpdatedAt)
                                    .FirstOrDefaultAsync();

            compSetting = _mapper.Map(DTO, compSetting);
            _context.SMSSettings.Update(compSetting);
            await _context.SaveChangesAsync();
            return compSetting;
        }


        public async Task<SMSSetting> GetSMSSettings()
        {
            var compSetting = await _context.SMSSettings
                                        //.OrderByDescending(cs => cs.UpdatedAt)
                                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Settings Not Found");
            return compSetting;

        }

    }
}
