using DentalClinic.DTOs.ReferralDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.ReferralService
{
    public interface IReferralService
    {
        Task<Referral> AddReferral(AddReferralDTO referralDTO);
        Task<bool> DeleteReferrals(int id);
        Task<List<Referral>> GetAllReferrals();
        Task<List<Referral>> GetReferralByEmployee(int employeeId);
        Task<List<Referral>> GetReferralByPatient(int patientId);
        Task<Referral> GetSpecificReferral(int id);
        Task<Referral> UpdateReferral(UpdateReferralDTO DTO);
    }
}