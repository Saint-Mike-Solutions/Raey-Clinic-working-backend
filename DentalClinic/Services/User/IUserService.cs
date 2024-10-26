using DentalClinic.Models;

namespace DentalClinic.Services.User
{
    public interface IUserService
    {
        Employee Employee { get; }
        Role UserRole { get; }

        int GetMyId();
        string GetMyName();
        int GetMySiteId();
    }
}