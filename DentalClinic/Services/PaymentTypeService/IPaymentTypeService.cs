using DentalClinic.DTOs.PaymentDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.PaymentTypeService
{
    public interface IPaymentTypeService
    {
        Task<PaymentType> AddPaymentType(AddPaymentTypeDTO DTO);
        Task<List<PaymentType>> GetAllPaymentTypes();
        Task<PaymentType> RemovePaymentType(int PaymentType);
    }
}