using DentalClinic.DTOs.SpecialCasesDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.SpecialCasesService
{
    public interface ISpecialCasesService
    {
        Task<SpecialCases> AddSpecialCases(AddSpecialCasesDTO DTO);
        Task<SpecialCases> DeleteSpecialCases(int id);
        Task<List<SpecialCases>> getAllSpecialCases();
        Task<SpecialCases> getSpecificSpecialCase(int id);
        Task<SpecialCases> updateSpecialCase(UpdateSpecialCasesDTO DTO);
    }
}