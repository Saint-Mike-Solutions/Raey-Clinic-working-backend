using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.RoleDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace DentalClinic.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RoleService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> AddRole(AddRoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> DeleteRole(string roleName)
        {
            var role = await _context.Roles
                    .Where(ro => ro.RoleName == roleName)
                    .FirstOrDefaultAsync();

            if (role == null) throw new KeyNotFoundException("Role Not Found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return role;
        }
        public async Task<List<Role>> GetRoles()
        {
            var role = await _context.Roles
                            .Include(ra => ra.UserAccounts)
                             .ToListAsync();
            return role;
        }

        public async Task<Role> UpdateRole(UpdateRoleDTO roleDTO)
        {
            var role = await _context.Roles
                    .Where(ro=>ro.RoleID == roleDTO.RoleIds)
                    .FirstOrDefaultAsync();
            if (role == null) throw new KeyNotFoundException("Role Not Found");
            role = _mapper.Map(roleDTO, role);
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;

        }

    }
}
