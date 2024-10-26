using DentalClinic.DTOs.LaboratoryRequestsDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.LaboratoryService
{
    public interface ILaboratoryService
    {
        Task<Bacterology> AddBacterology(AddBacterologyDTO DTO);
        Task<Chemistry> AddChemistry(AddChemistryDTO DTO);
        Task<Hematology> AddHematology(AddHematologyDTO DTO);
        Task<Microscopy> AddMicroscopy(AddMicroscopyDTO DTO);
        Task<Serology> AddSerology(AddSerologyDTO DTO);
        Task<StoolExamination> AddStoolExamination(AddStoolExaminationDTO DTO);
        Task<Urinalysis> AddUrinalysis(AddUrinalysisDTO DTO);
        Task<LaboratoryRequests?> CreateLaboratoryRequests(AddLaboratoryRequestsDTO DTO);
        Task<bool> DeleteLabRequest(int id);
        Task<List<LaboratoryRequests>> GetLaboratoryReportedBy(int employeeId);
        Task<List<LaboratoryRequests>> GetLaboratoryRequestedBy(int employeeId);
        Task<List<LaboratoryRequests>> GetLaboratoryRequests();
        Task<List<LaboratoryRequests>> GetPatientLabReports(int patientID);
        Task<LaboratoryRequests> GetSpecificLabRequest(int id);
        Task<LaboratoryRequests?> UpdateLabReport(UpdateLaboratoryRequestDTO DTO);
    }
}