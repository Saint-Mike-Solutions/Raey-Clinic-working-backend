using DentalClinic.Models;

namespace DentalClinic.Services.Tools
{
    public interface IToolsService
    {
        int CalculateAge(DateTime birthDate);
        DateTime CalculateDOB(int age);
        void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt);
        string CreateToken(UserAccount UA, Employee emp);
        string[] ReturnArrayofCommaSeparatedStrings(string inputString);
        bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt);
    }
}