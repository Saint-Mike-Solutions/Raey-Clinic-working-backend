using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.MobileBankingService
{
    public class MobileBankingService : IMobileBankingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public MobileBankingService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<MobileBanking> AddMobileBanking(AddMobileBankingDTO DTO)
        {
            MobileBanking MobileBanking = new MobileBanking
            {
                MobileBankingName = DTO.BankName
            };
            _context.MobileBanking.Add(MobileBanking);
            await _context.SaveChangesAsync();
            return MobileBanking;
        }
        public async Task<MobileBanking> RemoveMobileBanking(RemoveMobileBankingDTO DTO)
        {
            var MB = await _context.MobileBanking.Where(mb => mb.MobileBankingID == DTO.Id)
                                    .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Bank Not Found");
            _context.MobileBanking.Remove(MB);
            await _context.SaveChangesAsync();
            return MB;

        }
        public async Task<List<MobileBanking>> GetAllMobileBankings()
        {
            var MB = await _context.MobileBanking
                .OrderByDescending(c=> c.MobileBankingName)
                .ToListAsync();
            return MB;
        }
        public async Task<MobileBanking> UpdateMobileBanking(UpdateMobileBankingDTO DTO)
        {
            var MB = await _context.MobileBanking.Where(mb => mb.MobileBankingID == DTO.id)
                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Bank Not Found");
            MB.MobileBankingName = DTO.name;
            _context.MobileBanking.Update(MB);
            await _context.SaveChangesAsync();
            return MB;
        }
    }
}
