using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.DTOs.PaymentDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Payment> AddPaymentfromMedicalRecord(MakePaymentMedRecDTO DTO);
        Task<GetMDforPaymentDTO> GetMedicalRecordsforPayment(int id);
        Task<DisplayPaymentHistoryDTO> PaymentHistoryDetails(int DTO);
        Task<List<Payment>> PaymentLogForAll();
        Task<List<Payment>> PaymentLogForPatient(int DTO);
    }
}