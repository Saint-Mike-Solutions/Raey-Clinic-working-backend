using DentalClinic.DTOs.ReportDTO;

namespace DentalClinic.Services.ReportService
{
    public interface IReportService
    {
        Task<RevenuesDisplayDTO> CollectedAmounts(DateTimeRangeDTO DTO);
        Task<RevenuesDisplayDTO> CreditedAmount(DateTimeRangeDTO DTO);
        Task<List<object>> GenderBySubCity(DateTimeRangeDTOForCity DTO);
        //Task<List<ProcedureRevenue>> GetProcedureRevenues();
        Task<List<ProcedureRevenue>> GetProcedureRevenues(DateTimeRangeDTO DTO);
        //Task<List<ProcedureUsage>> GetProcedureUsage();
        Task<List<ProcedureUsage>> GetProcedureUsage(DateTimeRangeDTO DTO);
        Task<List<object>> GetRoleGenderCounts();
        Task<RevenuesDisplayDTO> Revenues(DateTimeRangeDTO DTO);
        Task<List<object>> TotalActiveInactiveEmployeesByRole();
        Task<List<object>> TotalDentistsPerGender();
        Task<RevenuesDisplayDTO> TotalNumberOfDentists();
        Task<RevenuesDisplayDTO> TotalNumberOfEmployees();
        Task<RevenuesDisplayDTO> TotalNumberOfPatient();
        Task<List<object>> TotalNumberofPatientByGender();
        Task<RevenuesDisplayDTO> TotalNumberOfProcedures();
        Task<List<object>> TotalRevenuePerMonthPastFiveYears();
        Task<List<object>> TotalRevenuesPerGender(DateTimeRangeDTO DTO);
        Task<List<object>> TotalUsers();
    }
}