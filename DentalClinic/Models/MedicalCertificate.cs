using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class MedicalCertificate
    {
        [Key]
        public int CardNumber { get; set; }

        public string? Diagnosis { get; set; }

        public string? SickLeave { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? AttendedFrom { get; set; }

        public DateTime? UpTo { get; set; }

        // Foreign key for Employee
        public int? EmployeeId { get; set; }  // This allows the EmployeeId to be null if needed
        public Employee? Employee { get; set; }

        // Foreign key for Patient
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
