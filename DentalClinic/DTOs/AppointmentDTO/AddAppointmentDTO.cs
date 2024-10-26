using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.AppointmentDTO
{
    public class AddAppointmentDTO
    {
        public int PatientID { get; set; }
        public int? DentistID { get; set; }
        public DateTime AppointmentSetDate { get; set; } = DateTime.Now;
        public DateTime AppointmentStartTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public int? ActionByID { get; set; }

        public string ActionName { get; set; } = string.Empty;
        public bool AllDay { get; set; }
        public string ActivityName { get; set; } = string.Empty;

    }
}
