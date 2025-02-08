using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.SpecialCasesDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.SpecialCasesService
{
    public class SpecialCasesService : ISpecialCasesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SpecialCasesService> _logger;

        private readonly IToolsService _toolsService;
        public SpecialCasesService(DataContext context)
        {
            _context = context;
            //_mapper = mapper;
            //_toolsService = toolsService;
            //_logger = logger; // Inject the logger

        }

        public async Task<SpecialCases> AddSpecialCases(AddSpecialCasesDTO DTO)
        {
            var sc = new SpecialCases();
            sc.Description = DTO.Description;
            sc.SpecialCaesName = DTO.SpecialCaesName;

            await _context.SpecialCases.AddAsync(sc);
            await _context.SaveChangesAsync();
            return sc;
        }

        public async Task<SpecialCases> DeleteSpecialCases(int id)
        {
            var sc = await _context.SpecialCases.Where(s => s.SpecialCaesId == id).FirstOrDefaultAsync();
            if (sc == null)
            {
                throw new Exception("Special Case doesn't exist");
                return null;
            }

            _context.SpecialCases.Remove(sc);
            await _context.SaveChangesAsync();
            return sc;

        }

        public async Task<List<SpecialCases>> getAllSpecialCases()
        {
            var sc = await _context.SpecialCases.ToListAsync();
            return sc;
        }

        public async Task<SpecialCases> getSpecificSpecialCase(int id)
        {
            var sc = await _context.SpecialCases.Where(i => i.SpecialCaesId == id).FirstOrDefaultAsync();
            if (sc == null)
            {
                throw new Exception("Special Case doesn't exist");
                return null;
            }
            return sc;
        }

        public async Task<SpecialCases> updateSpecialCase(UpdateSpecialCasesDTO DTO)
        {
            var sc = await _context.SpecialCases.Where(i => i.SpecialCaesId == DTO.SpecialCaseId).FirstOrDefaultAsync();
            if (sc == null)
            {
                throw new Exception("Special Case doesn't exist");
                return null;
            }

            sc.SpecialCaesName = DTO.SpecialCaesName;
            sc.Description = DTO.Description;

            _context.SpecialCases.Update(sc);
            await _context.SaveChangesAsync();
            return sc;
        }

    }
}
