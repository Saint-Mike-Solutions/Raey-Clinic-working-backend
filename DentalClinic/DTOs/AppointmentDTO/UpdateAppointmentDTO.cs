namespace DentalClinic.DTOs.AppointmentDTO
{
    public class UpdateAppointmentDTO
    {
        public int AppointmentID { get; set; }
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
