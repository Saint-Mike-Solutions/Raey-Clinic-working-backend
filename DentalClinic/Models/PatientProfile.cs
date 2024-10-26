using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class PatientProfile
    {
        [Key]
        [ForeignKey("Patient")]

        [System.Text.Json.Serialization.JsonIgnore]
        public int Patient_Id { get; set; }

        public string MedicalHistory { get; set; } = string.Empty;

        public string Allergies { get; set; } = string.Empty;

        public string Chronics { get; set; } = string.Empty;

        public Patient? Patient { get; set; }
    }
}
