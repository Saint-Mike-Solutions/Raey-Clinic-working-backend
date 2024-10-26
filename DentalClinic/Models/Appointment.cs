using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
        [ForeignKey("Dentist")]
        public int? DentistID { get; set; }
        public Employee? Dentist { get; set; } 
        public DateTime AppointmentSetDate { get; set; } = DateTime.Now;
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set;}
        [ForeignKey("ActionBy")]
        public int? ActionByID { get; set; }

        public Employee? ActionBy { get; set; } 
        public string ActionName { get; set; } = string.Empty;
        public bool AllDay { get; set; }

        public string? ActivityName { get; set; }

    }
}
