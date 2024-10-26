using DentalClinic.DTOs.CreditDTO;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.CreditService
{
    public interface ICreditService
    {
        Task<Credit> ChargeCredit(ChargeCreditDTO DTO);
        Task<List<DisplayCreditHistoryDTO>> CreditHistoryForPatient(int DTO);
        Task<Credit> CurrentCreditInfo(int DTO);
        Task<List<PatientWithCreditDTO>> LoanExpireAfter();
        Task<List<PatientWithCreditDTO>> PatientsWithLoan();
    }
}