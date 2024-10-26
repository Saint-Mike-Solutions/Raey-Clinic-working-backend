using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class PatientVisit
    {
        [Key]
        public int VisitID { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; } 
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Employee? Doctor { get; set; }
        public string ReasonForVisit { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string TreatmentProvided { get;  set; } = string.Empty;  
        public DateTime CreatedAt { get; set; }  = DateTime.Now;

    }
}
