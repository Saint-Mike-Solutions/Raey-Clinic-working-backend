using DentalClinic.DTOs;
using DentalClinic.Models;

namespace DentalClinic.Services.PrescriptionService
{
    public interface IPrescriptionService1
    {
        Task<Prescription> CreatePrescriptionAsync(AddPrescriptionDTO prescription);
        Task<bool> DeletePrescriptionAsync(int id);
        Task<List<Prescription>> GetAllPrescriptionsAsync();
        Task<List<Prescription?>> GetPrescriptionByEmployee(int id);
        Task<Prescription?> GetPrescriptionByIdAsync(int id);
        Task<List<Prescription?>> GetPrescriptionByPatient(int id);
        Task<Prescription?> UpdatePrescriptionAsync(UpdatePrescriptionDTO updatedPrescription);
    }
}