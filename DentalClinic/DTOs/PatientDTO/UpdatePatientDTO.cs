namespace DentalClinic.DTOs.PatientDTO
{
    public class UpdatePatientDTO
    {
        public int PatientID { set; get; }
        public string PatientFullName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public Decimal Weight { get; set; }
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

        public string Chronics { get; set; } = string.Empty;

    }
}
