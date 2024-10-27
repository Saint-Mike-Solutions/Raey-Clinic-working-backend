using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.CompanyLabPricesDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.CompanyLabPricesService
{
    public class CompanyLabPricesService : ICompanyLabPricesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public CompanyLabPricesService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<CompanyLabPrices> AddCompanyLabPrices(AddCompanyLabPricesDTO DTO)
        {
            var alreadyExists = await _context.CompanyLabPrices.FirstOrDefaultAsync();



            if (alreadyExists == null)
            {

                CompanyLabPrices company = new CompanyLabPrices
                {
                    BacterologyPrice = DTO.BacterologyPrice,
                    UrinalysisPrice = DTO.UrinalysisPrice,
                    ChemistryPrice = DTO.ChemistryPrice,
                    HematologyPrice = DTO.HematologyPrice,
                    MicroscopyPrice = DTO.MicroscopyPrice,
                    StoolExamPrice = DTO.StoolExamPrice,
                    SerologyPrice = DTO.SerologyPrice,

                };


                await _context.CompanyLabPrices.AddAsync(company);
                await _context.SaveChangesAsync();
                return company;
            }
            else
            {
                alreadyExists.SerologyPrice = DTO.SerologyPrice;
                alreadyExists.StoolExamPrice = DTO.StoolExamPrice;
                alreadyExists.MicroscopyPrice = DTO.MicroscopyPrice;
                alreadyExists.HematologyPrice = DTO.HematologyPrice;
                alreadyExists.ChemistryPrice = DTO.ChemistryPrice;
                alreadyExists.UrinalysisPrice = DTO.UrinalysisPrice;
                alreadyExists.BacterologyPrice = DTO.BacterologyPrice;


                _context.CompanyLabPrices.Update(alreadyExists);
                await _context.SaveChangesAsync();
                return alreadyExists;

            }
        }

        public async Task<CompanyLabPrices> GetLabPrices()
        {
            var alreadyExists = await _context.CompanyLabPrices.FirstOrDefaultAsync();
            if (alreadyExists == null)
            {
                return null;
            }
            return alreadyExists;
        }
    }

}
