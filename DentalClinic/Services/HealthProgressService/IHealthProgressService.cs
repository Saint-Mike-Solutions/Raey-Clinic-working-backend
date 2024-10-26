using DentalClinic.DTOs.HealthProgressDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.HealthProgressService
{
    public interface IHealthProgressService
    {
        Task<HealthProgress> AddHealthProgressToEmployee(AddHealthProgressDTO progressDTO);
        Task<List<HealthProgress>> GetHealthProgressesAdministeredByEmployee(int employeeId);
        Task<List<HealthProgress>> GetHealthProgressesForPatient(int patientId);
    }
}