using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class AppointmentLog
    {
        [Key]
        public int LogID { get; set; }
        public int AppointmentId { get; set; }
        public string? PatientName { get; set; }
        public string? DentistName { get; set; }
        public DateTime AppointmentSetDate { get; set; } 
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string? ActionByName { get; set; }
        public string? ActionName { get; set; } 
        public bool AllDay { get; set; }

        public string ActivityName { get; set; } = string.Empty;

        public DateTime LogDate { get; set; }
    }
}
