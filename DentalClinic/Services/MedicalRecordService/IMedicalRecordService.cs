using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.MedicalRecordService
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecord> AddMedicalRecord(AddMedicalRecordDTO recordDTO);
        Task<MedicalRecord> DeleteMedicalRecord(int MedicalRecordID);
        Task<List<DisplayMedicalRecordDTO>> GetAllMedicalRecords();
        Task<List<DisplayMedicalRecordDTO>> GetAllMedicalRecordsByPatientId(int id);
        Task<MedicalRecord> UpdateMedicalRecord(UpdateMedicalRecordDTO MrDto);
    }
}