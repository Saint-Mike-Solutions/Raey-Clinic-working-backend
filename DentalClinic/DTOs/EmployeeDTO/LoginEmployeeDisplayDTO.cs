using DentalClinic.Models;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.EmployeeDTO
{
    public class LoginEmployeeDisplayDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"([0-9]){9}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string EmployeeGender { get; set; } = string.Empty;
        public Boolean IsCurrentlyActive { get; set; } = true;
        public DateTime? DateOfTermination { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }


        //public string EmployeePostition { get; set; } = string.Empty;

        //public int UserAccountId { get; set; }

        //public int useraccountid { get; set; }

        public List<MedicalRecord>? MedicalRecordAdministered { get; set; }
        public List<HealthProgress>? HealthProgresses { get; set; }
        public UserAccount? UserAccount { get; set; }

        public Role? role { get; set; }

        public List<PatientVisit>? PatientVisits { get; set; }

        //public List<Referal>? Referals { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
