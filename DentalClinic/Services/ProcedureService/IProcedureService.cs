using DentalClinic.DTOs.ProcedureDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.ProcedureService
{
    public interface IProcedureService
    {
        Task<Procedure> AddProcedure(AddProcedureDTO procedureDTO);
        Task<Procedure> DeleteProcedure(string procedureName);
        //Task<List<Procedure>> GetProcedures();
        Task<List<Procedure>> GetProcedures();
        Task<Procedure> UpdateProcedure(UpdateProcedureDTO procedureDTO);
    }
}