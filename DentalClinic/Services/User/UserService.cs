using DentalClinic.Context;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DentalClinic.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Role UserRole { get; }
        public Employee Employee { get; }
        private readonly DataContext _context;
        //private readonly IUserRoleService _userRoleService;

        public UserService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;

            var UserAccount = context.UserAccounts
                .Where(u => u.UserName == GetMyName())
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .FirstOrDefault();


            Employee = UserAccount == null ? null : UserAccount.Employee;
            UserRole = Employee == null ? null : UserAccount.Role;
        }

        public  string GetMyName()
        {
            var result = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {

                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        public int GetMyId()
        {
            var result = 0;

            if (_httpContextAccessor.HttpContext != null)
            {
                var employeeId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid);

                result = Convert.ToInt32(employeeId);

            }

            return result;
        }

        public int GetMySiteId()
        {
            var result = 0;

            if (_httpContextAccessor.HttpContext != null)
            {
                var employeeId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid);

                result = Convert.ToInt32(employeeId);

            }

            return result;
        }
    }
}
