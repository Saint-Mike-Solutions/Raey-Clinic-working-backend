using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class LaboratoryRequestList
    {
        [Key]
        public int Id {  get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }
        public Employee Requester { get; set; }

        public int EmployeeId { get; set; }

        public bool Hematology { get; set; }

        public bool Chemistry { get; set; }

        public bool Serology { get; set; }

        public bool Urinalysis { get; set; }

        public bool Bacterology { get; set; }

        public bool Microscopy { get; set; }

        public bool StoolExamination { get; set; }

        public string? Status { get; set; } = "Pending";
        
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
