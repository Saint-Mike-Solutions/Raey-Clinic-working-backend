using DentalClinic.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class Employee

    {
        [Key]
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

       public List<PatientVisit>? PatientVisits { get; set; }

        //public List<Referal>? Referals { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public List<Credit>? Credits { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]


        public int? DepartmentID { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public Department? Departments { get; set; }
        public List<Prescription>? Prescriptions { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<MedicalCertificate>? MedicalCertificatesHanded { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Referral>? ReferralsWritten { get; set;  }

        [System.Text.Json.Serialization.JsonIgnore]

        public List<LaboratoryRequests>? LaboratoryRequests { get; set; }


        public List<LaboratoryRequestList>? ListOfLaboratoryRequests { get; set; }

    }
}
