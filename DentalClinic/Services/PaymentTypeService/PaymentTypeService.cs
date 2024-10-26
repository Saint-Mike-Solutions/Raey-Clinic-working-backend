using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.PaymentDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.PaymentTypeService
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public PaymentTypeService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<PaymentType> AddPaymentType(AddPaymentTypeDTO DTO)
        {

            var type = new PaymentType
            {
                PaymentName = DTO.Name
            };
            await _context.paymentTypes.AddAsync(type);
            await _context.SaveChangesAsync();
            return type;
        }
        public async Task<PaymentType> RemovePaymentType(int PaymentType)
        {
            var type = await _context.paymentTypes
                     .Where(c => c.Id == PaymentType)
                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Payment Type Not Found!");
            _context.paymentTypes.Remove(type);
            await _context.SaveChangesAsync();
            return type;
        }
        public async Task<List<PaymentType>> GetAllPaymentTypes()
        {
            var paymentTypes = await _context.paymentTypes
                            .OrderByDescending(c => c.PaymentName)
                            .ToListAsync();
            return paymentTypes;
        }
    }
}
