using DentalClinic.Models;

namespace DentalClinic.DTOs.PatientDTO
{
    public class DisplayPatientDTO
    {
        public int PatientId { set; get; }
        public string PatientFullName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public Decimal? Weight { get; set; }
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

        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public string MedicalHistory { get; set; } = string.Empty;

        public string Allergies { get; set; } = string.Empty;

        public bool CardNeeded { get; set; }
        public string Chronics { get; set; } = string.Empty;

        public List<Referral> referals { get; set; }

        public List<Prescription> prescriptions { get; set; }

        public LaboratoryRequests? laboratoryRequests { get; set; }
    }
}
