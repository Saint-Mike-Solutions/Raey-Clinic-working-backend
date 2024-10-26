using DentalClinic.DTOs.RoleDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.RoleService
{
    public interface IRoleService
    {
        Task<Role> AddRole(AddRoleDTO roleDTO);
        Task<Role> DeleteRole(string roleName);
        Task<List<Role>> GetRoles();
        Task<Role> UpdateRole(UpdateRoleDTO roleDTO);
    }
}