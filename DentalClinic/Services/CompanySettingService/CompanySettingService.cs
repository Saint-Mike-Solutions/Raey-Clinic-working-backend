using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DentalClinic.Services.CompanySettingService
{
    public class CompanySettingService : ICompanySettingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompanySettingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Update works by updating only 1 record that's in the database and changing it
        public async Task<CompanySetting> AddCompanySetting(AddCompanySettingsDTO add)
        {
            var num = await _context.CompanySettings.CountAsync();
            if (num >= 1)
            {
                throw new Exception("Company setting is already set, update the existing setting.");
            }
            var compSetting = _mapper.Map<CompanySetting>(add);
            compSetting.EarlyReminderForLoan = add.EarlyReminderForLoan;
            _context.CompanySettings.Add(compSetting);
            await _context.SaveChangesAsync();
            return compSetting;
        }
        public async Task<CompanySetting> UpdateComapnySetting(UpdateCompanySettingDTO update)
        {
            var compSetting = await _context.CompanySettings
                                    .OrderByDescending(u=> u.UpdatedAt)
                                    .FirstOrDefaultAsync();

                compSetting = _mapper.Map(update, compSetting);
            compSetting.EarlyReminderForLoan = update.EarlyReminderForLoan;
                _context.CompanySettings.Update(compSetting);
                await _context.SaveChangesAsync();
                return compSetting;
        }


        public async Task<CompanySetting> GetCompanySetting()
        {
            var compSetting = await _context.CompanySettings
                                        .OrderByDescending(cs => cs.UpdatedAt)
                                        .FirstOrDefaultAsync()??throw new KeyNotFoundException("Settings Not Found");
            return compSetting;

        }


    }
}


