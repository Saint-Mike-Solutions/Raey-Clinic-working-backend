using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.DTOs.LogInDTO
{
    public class LoginDTO
    {

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
