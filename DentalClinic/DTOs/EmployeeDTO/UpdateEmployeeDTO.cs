namespace DentalClinic.DTOs.EmployeeDTO
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string EmployeeGender { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int DepartmentID { get; set; }
        public bool IsCurrentlyActive { get; set; }
        public string UserName1 { get; set; } = null!;

        public string RoleName { get; set; } = null!;
    }
}
