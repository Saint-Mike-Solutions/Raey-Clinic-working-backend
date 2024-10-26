using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.LogInDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployee(AddEmployeeDTO employeeDTO);
        Task<Employee> DeleteEmployee(int id);
        Task<int> GetTotalEmployeeCountAsync();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> UpdateEmployee(UpdateEmployeeDTO employeeDTO);
        Task<List<DisplayEmployeeDTO>> GetAllEmployee();
        Task<List<DisplayEmployeeDTO>> GetAllHiredEmployee();
        Task<LoginEmployeeDisplayDTO> Login(LoginDTO login);
        Task<string> RestorePassword(RestorePasswordDTO DTO);
        Task<string> ChangePassword(ChangePasswordDTO DTO);
        Task<List<MedicalCertificate>> GetMedicalCertificates();
    }
}