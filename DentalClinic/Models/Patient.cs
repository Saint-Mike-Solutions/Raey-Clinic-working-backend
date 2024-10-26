using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string? PatientFullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        public Decimal? Weight { get; set; }

        [RegularExpression(@"([0-9]){9}$", ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; } 
        public string? Gender { get; set; } 

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Subcity { get; set; }

        public string? Region { get; set; }

        public string? Town { get; set; }

        public string? Woreda { get; set; }

        public string? Kebele { get; set; }

        public string? HouseNumber { get; set; }

        public string? Occupation { get; set; }

        public string? Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<HealthProgress>? HealthProgresses { get; set; }

        public List<MedicalRecord>? MedicalRecords { get; set; }

        public PatientProfile? Profile { get; set; }

        public List<PatientVisit>? PatientVisits { get; set;}
        [System.Text.Json.Serialization.JsonIgnore]

        public List<Appointment>? Appointments { get; set;}

        public PatientCard? PatientCard { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public List<Credit>? Credits { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public List<Prescription>? Prescriptions { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<MedicalCertificate>? MedicalCertificates { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]

        public List<Referral>? Referrals { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore]

        public LaboratoryRequests? LaboratoryRequests { get; set; }


        public List<LaboratoryRequestList>? LaboratoryRequestsList { get; set; }


    }
}
