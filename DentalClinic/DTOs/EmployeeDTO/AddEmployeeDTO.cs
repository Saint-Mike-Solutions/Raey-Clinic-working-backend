using DentalClinic.Models;

namespace DentalClinic.DTOs.EmployeeDTO
{
    public class AddEmployeeDTO
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string EmployeeGender { get; set; } = string.Empty;
        public Boolean IsCurrentlyActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int DepartmentID { get; set; }

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string RoleName { get; set; } = null!;


    }
}
