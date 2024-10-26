using DentalClinic.Models;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.MedicalCertificateDTO
{
    public class AddMedicalCertificateDTO
    {
        public string? Diagnosis { get; set; }

        public string? SickLeave { get; set; }

        public DateTime? AttendedFrom { get; set; } = DateTime.Now;

        public DateTime? UpTo { get; set; } = DateTime.Now;

        // Foreign key for Employee
        public int EmployeeId { get; set; } 

        // Foreign key for Patient
        public int PatientId { get; set; }
    }
}
