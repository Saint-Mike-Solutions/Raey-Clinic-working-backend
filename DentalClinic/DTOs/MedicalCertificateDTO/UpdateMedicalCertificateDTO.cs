using DentalClinic.Models;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.MedicalCertificateDTO
{
    public class UpdateMedicalCertificateDTO
    {
        public int CardNumber { get; set; }

        public string? Diagnosis { get; set; }

        public string? SickLeave { get; set; }

        public DateTime? AttendedFrom { get; set; }

        public DateTime? UpTo { get; set; }

        // Foreign key for Employee
    }
}
