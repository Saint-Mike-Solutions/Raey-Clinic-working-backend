namespace DentalClinic.DTOs.EmployeeDTO
{
    public class ChangePasswordDTO
    {
        public int User_Id { get; set; }
        public string OldPassword { get; set; } = null!;
        public string New_Password { get; set; } = null!;
    }
}
