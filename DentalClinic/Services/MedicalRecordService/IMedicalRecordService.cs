using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.MedicalRecordService
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecord> AddMedicalRecord(AddMedicalRecordDTO recordDTO);
        Task<List<DisplayMedicalRecordDTO>> GetAllMedicalRecords();
        Task<List<DisplayMedicalRecordDTO>> GetMedicalRecordById(int id);
        Task<MedicalRecord> UpdateMedicalRecord(UpdateMedicalRecordDTO MrDto);

        //Task<List<MedicalRecord>> GetMedicalRecordforPatient(int patientID);
    }
}