using AutoMapper;
using DentalClinic.Context;
using DentalClinic.Models;
using DentalClinic.DTOs.EmployeeDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DentalClinic.Services.Tools;
using DentalClinic.DTOs.LogInDTO;
using DentalClinic.DTOs.MedicalRecordDTO;

namespace DentalClinic.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public EmployeeService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<Employee> AddEmployee(AddEmployeeDTO employeeDTO)
        {
            //var employee = _mapper.Map<Employee>(employeeDTO);

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == employeeDTO.RoleName);

            if (role == null)
            {
                // Handle the case where the role does not exist
                throw new ApplicationException($"Role '{employeeDTO.RoleName}' not found.");
            }


            var userAccount = new UserAccount
            {
                UserName = employeeDTO.UserName,
                Role = role
            };
            _toolsService.CreatePasswordHash(employeeDTO.Password, out byte[] PH, out byte[] PS);
            userAccount.PasswordHash = PH;
            userAccount.PasswordSalt = PS;

            var dpt = await _context.Departments.FindAsync(employeeDTO.DepartmentID);

            var employee = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                DateOfBirth = employeeDTO.DateOfBirth,
                EmployeeGender = employeeDTO.EmployeeGender,
                IsCurrentlyActive = employeeDTO.IsCurrentlyActive,
                CreatedAt = employeeDTO.CreatedAt,
                DepartmentID = employeeDTO.DepartmentID
            };
            employee.UserAccount = userAccount;
            employee.Departments = dpt;
            await _context.Employees.AddAsync(employee);



            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<int> GetTotalEmployeeCountAsync()
        {
            int totalCount = await _context.Employees.CountAsync();
            return totalCount;
        }
        public async Task<string> RestorePassword(RestorePasswordDTO DTO)
        {
            var employee = await _context.UserAccounts
                        .Where(e => e.UserAccountId == DTO.UserAccountID)
                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee Not Found");
            _toolsService.CreatePasswordHash("Password123", out byte[] PH, out byte[] PS);
            employee.PasswordHash = PH;
            employee.PasswordSalt = PS;
            _context.UserAccounts.Update(employee);
            await _context.SaveChangesAsync();
            return "Password Succesfully changed to Password123";

        }
        public async Task<List<DisplayEmployeeDTO>> GetAllHiredEmployee()
        {
            var employees = await _context.Employees
                                        .Where(e => e.IsCurrentlyActive == true)
                                        .Include(e => e.UserAccount)
                                            .ThenInclude(ua => ua.Role)
                                        .OrderByDescending(e => e.CreatedAt)
                                        .ToListAsync();

            if (employees != null)
            {
                var recordDTOs = employees.Select(r => new DisplayEmployeeDTO
                {
                    EmployeeId = r.EmployeeId,
                    EmployeeName = r.EmployeeName,
                    EmployeeGender = r.EmployeeGender,
                    Phone = r.Phone,
                    IsCurrentlyActive = r.IsCurrentlyActive,
                    DateOfBirth = r.DateOfBirth,
                    Email = r.Email,
                    CreatedAt = r.CreatedAt,
                    UserName = r.UserAccount != null ? r.UserAccount.UserName : "DefaultUserName",
                    RoleName = r.UserAccount != null && r.UserAccount.Role != null ? r.UserAccount.Role.RoleName : "DefaultRoleName",
                })
                .ToList()
                .OrderByDescending(r => r.EmployeeName)
                .ToList();

                return recordDTOs;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DisplayEmployeeDTO>> GetAllEmployee()
        {
            var employees = await _context.Employees
                                        .Include(e => e.UserAccount)
                                            .ThenInclude(ua => ua.Role)
                                        .OrderByDescending(e => e.CreatedAt)
                                        .ToListAsync();

            if (employees != null)
            {
                var recordDTOs = employees.Select(r => new DisplayEmployeeDTO
                {
                    EmployeeId = r.EmployeeId,
                    EmployeeName = r.EmployeeName,
                    EmployeeGender = r.EmployeeGender,
                    Phone = r.Phone,
                    IsCurrentlyActive = r.IsCurrentlyActive,
                    DateOfBirth = r.DateOfBirth,
                    Email = r.Email,
                    CreatedAt = r.CreatedAt,
                    UserName = r.UserAccount != null ? r.UserAccount.UserName : "DefaultUserName",
                    RoleName = r.UserAccount != null && r.UserAccount.Role != null ? r.UserAccount.Role.RoleName : "DefaultRoleName",
                })
                .ToList()
                .OrderByDescending(r => r.EmployeeName)
                .ToList();

                return recordDTOs;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await _context.Employees
                                   .FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Emp not found");
            }
            employee.IsCurrentlyActive = false;
            employee.DateOfTermination = DateTime.Now;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                            .Include(e => e.UserAccount)
                                   .ThenInclude(ua => ua.Role)
                            .FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsCurrentlyActive == true)
                            ?? throw new KeyNotFoundException("Emp not found");
            return employee;

        }
        public async Task<Employee> UpdateEmployee(UpdateEmployeeDTO employeeDTO)
        {
            var employee = await _context.Employees
                                    .Where(e => e.EmployeeId == employeeDTO.EmployeeID)
                                    .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee Not Found");
            //var employee = _mapper.Map<Employee>(employeeDTO);

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == employeeDTO.RoleName);
     

            if (role == null)
            {
                // Handle the case where the role does not exist
                throw new ApplicationException($"Role '{employeeDTO.RoleName}' not found.");
            }
            var dpt = await _context.Departments.FindAsync(employeeDTO.DepartmentID);
            employee = _mapper.Map(employeeDTO, employee);
            employee.DepartmentID = employeeDTO.DepartmentID;
            employee.Departments = dpt;
            employee.UpdateAt = employeeDTO.UpdatedAt;
            employee.IsCurrentlyActive = employeeDTO.IsCurrentlyActive;
            var UserAccount = await _context.UserAccounts
                                .Where(ua => ua.EmployeeId == employeeDTO.EmployeeID)
                                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User Account Not found!");
            UserAccount.UserName = employeeDTO.UserName1;
            //UserAccount.Password = employeeDTO.Password;
            UserAccount.Role = role;
            employee.IsCurrentlyActive = employeeDTO.IsCurrentlyActive;
            employee.UserAccount = UserAccount;



            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<string> ChangePassword(ChangePasswordDTO DTO)
        {
            var employee = await _context.UserAccounts
            .Where(e => e.UserAccountId == DTO.User_Id)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee Not Found");
            var OldPassword = DTO.OldPassword;
            if (!_toolsService.VerifyPasswordHash(OldPassword, employee.PasswordHash, employee.PasswordSalt))
            {
                throw new UnauthorizedAccessException("Old Password Invalid!");
            }
            _toolsService.CreatePasswordHash(DTO.New_Password, out byte[] PH, out byte[] PS);
            employee.PasswordHash = PH;
            employee.PasswordSalt = PS;
            _context.UserAccounts.Update(employee);
            await _context.SaveChangesAsync();
            return $"Password Successfully changed to {DTO.New_Password}";
        }
        public async Task<List<MedicalCertificate>> GetMedicalCertificates()
        {
            var MC = await _context.MedicalCertificates
                .Include(mc => mc.Patient)  // Include the related Patient
                .ToListAsync();

            return MC;
        }

        public async Task<LoginEmployeeDisplayDTO> Login(LoginDTO login)
        {
            var user = await _context.UserAccounts
                .Where(u => u.UserName == login.UserName)
                .Include(u => u.Role)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User Name Not found");

            var employee = await _context.Employees
                .Where(e => e.EmployeeId == user.EmployeeId)
                .Include(u => u.UserAccount)
                    .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee not found");

            if (!_toolsService.VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            var loginEmployeeDisplayDTO = new LoginEmployeeDisplayDTO
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Phone = employee.Phone,
                DateOfBirth = employee.DateOfBirth,
                EmployeeGender = employee.EmployeeGender,
                IsCurrentlyActive = employee.IsCurrentlyActive,
                DateOfTermination = employee.DateOfTermination,
                CreatedAt = employee.CreatedAt,
                UpdateAt = employee.UpdateAt,

                // Populate other properties based on your requirements
                // MedicalRecordAdministered = employee.MedicalRecordAdministered,
                // HealthProgresses = employee.HealthProgresses,
                UserAccount = employee.UserAccount,
                //role = employee.UserAccount.Role,
                // PatientVisits = employee.PatientVisits,
                // Referals = employee.Referals,
                // Appointments = employee.Appointments,

                Token = _toolsService.CreateToken(user, employee)
            };

            return loginEmployeeDisplayDTO;


        }
    }
}
