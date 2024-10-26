using DentalClinic.DTOs.MedicalCertificateDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.MedicalCertificates
{
    public interface IMedicalCertificateService
    {
        Task<MedicalCertificate> CreateMedicalCertificate(AddMedicalCertificateDTO DTO);
        Task<bool> DeleteMedicalCertificate(int id);
        Task<List<MedicalCertificate>> GetAllCertificates();
        Task<List<MedicalCertificate>> GetMedicalCertificatesByEmployee(int employeeId);
        Task<List<MedicalCertificate>> GetMedicalCertificatesByPatient(int patientId);
        Task<MedicalCertificate> GetSpecificCertificate(int id);
        Task<MedicalCertificate> UpdateMedicalCertificate(UpdateMedicalCertificateDTO DTO);
    }
}