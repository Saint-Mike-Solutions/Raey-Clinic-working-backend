using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.PatientDTO;
using DentalClinic.DTOs.Pricing;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.PricingService
{
    public class PricingService : IPricingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PricingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PricingReason> AddPricingReason(AddPricingReasonDTO pricingReasonDTO)
        {
            var re = _mapper.Map<PricingReason>(pricingReasonDTO);
            _context.pricingReasons.Add(re);
            await _context.SaveChangesAsync();
            return re;

        }
        public async Task<List<PricingReason>> GetPricingReasonsList()
        {
            var pr = await _context.pricingReasons.ToListAsync()??throw new KeyNotFoundException("Reasons Not Found") ;
            return pr;
        }
        public async Task<List<PricingDescription>> GetPricingDescriptions()
        {
            var pr = await _context.pricingDescriptions.ToListAsync() ?? throw new KeyNotFoundException("Descriptions Not Found");
            return pr;
        }
        public async Task<PricingDescription> AddPricingDescription(AddPricingDescriptionDTO pricingDescriptionDTO)
        {
            var re = _mapper.Map<PricingDescription>(pricingDescriptionDTO);
            _context.pricingDescriptions.Add(re);
            await _context.SaveChangesAsync();
            return re;

        }
        public async Task<PricingDescription> DeletePricingDescription(int id)
        {
            var pr = await _context.pricingDescriptions.Where(pr => pr.PricingDescriptionId == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Pricing Description Not found");
            _context.pricingDescriptions.Remove(pr);
            await _context.SaveChangesAsync();
            return pr;
        }
        public async Task<PricingReason> DeletePricingReason(int id)
        {
            var pr = await _context.pricingReasons.Where(pr => pr.PricingReasonID == id).FirstOrDefaultAsync()??throw new KeyNotFoundException("Pricing Reason Not found");
            _context.pricingReasons.Remove(pr);
            await _context.SaveChangesAsync();
            return pr;
        }
        public async Task<PricingDescription> UpdatePricingDescription(UpdatePricingDescriptionDTO DTO)
        {
            var pd = await _context.pricingDescriptions.Where(pr => pr.PricingDescriptionId == DTO.Id).FirstOrDefaultAsync()?? throw new KeyNotFoundException("Pricing Description not Found");
            pd = _mapper.Map(DTO, pd);
            _context.pricingDescriptions.Update(pd);
            await _context.SaveChangesAsync();
            return pd;
        }
        public async Task<PricingReason> UpdatePricingReason(UpdatePricingReasonDTO DTO)
        {
            var pd = await _context.pricingReasons.Where(pr => pr.PricingReasonID == DTO.Id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Pricing Reason not Found");
            pd = _mapper.Map(DTO, pd);
            _context.pricingReasons.Update(pd);
            await _context.SaveChangesAsync();
            return pd;

        }
    }
}
