using DentalClinic.DTOs.DepartmentController;
using DentalClinic.Models;

namespace DentalClinic.Services.CompanySettingService
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(AddDepartmentDTO DTO);
        Task<bool> DeleteDepartments(int id);
        Task<List<Department>> GetDepartments();
        Task<Department> UpdateDepartment(UpdateDepartmentDTO DTO);
    }
}