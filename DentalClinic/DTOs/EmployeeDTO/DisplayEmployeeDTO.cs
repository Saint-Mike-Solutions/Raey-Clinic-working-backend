namespace DentalClinic.DTOs.EmployeeDTO
{
    public class DisplayEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string EmployeeGender { get; set; } = string.Empty;

        public Boolean IsCurrentlyActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
