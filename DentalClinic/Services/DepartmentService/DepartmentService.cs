using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.DepartmentController;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.Models;
using DentalClinic.Services.EmployeeService;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DentalClinic.Services.CompanySettingService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Update works by updating only 1 record that's in the database and changing it
        public async Task<Department> AddDepartment(AddDepartmentDTO DTO)
        {
            Department dpt = new Department
            {
                //Patient = patient,
                DepartmentName = DTO.DepartmentName,

            };
            _context.Departments.Add(dpt);
            await _context.SaveChangesAsync();
            return dpt;
        }
        public async Task<Department> UpdateDepartment(UpdateDepartmentDTO DTO)
        {
            var dpt = await _context.Departments.FindAsync(DTO.id);
            if (dpt == null)
            {
                return null;
            }
            dpt.DepartmentName = DTO.DepartmentName;
            _context.Departments.Update(dpt);
            await _context.SaveChangesAsync();

            return dpt;


        }


        public async Task<List<Department>> GetDepartments()
        {
            var dpts = await _context.Departments
                                       .Include(d => d.Employees)
                                      .ToListAsync();
            return dpts;
        }

        public async Task<bool> DeleteDepartments(int id)
        {
            var dpt = await _context.Departments.FindAsync(id);
            if (dpt == null)
            {
                return false; // Prescription not found
            }

            _context.Departments.Remove(dpt);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}


