using DentalClinic.DTOs.LaboratoryRequestListDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.LaboratoryRequestListService
{
    public interface ILaboratoryRequestListService
    {
        Task<LaboratoryRequestList> AddLaboratoryRequestList(AddLaboratoryRequestListDTO DTO);
        Task<LaboratoryRequestList> DeleteLabRequestList(int id);
        Task<List<LaboratoryRequestList>> GetAllLaboratoryRequestLists();
        Task<LaboratoryRequestList> GetLabReqListById(int id);
        Task<LaboratoryRequestList> UpdateLabRequestList(UpdateLaboratoryRequestListDTO DTO);
    }
}