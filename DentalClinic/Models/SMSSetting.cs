namespace DentalClinic.Models
{
    public class SMSSetting
    {
        public int ID { get; set; }

        public string? SMSApi { get; set; } 

        public string? DeviceId { get; set; }

        public string? LoanExpireSMS { get; set; }

        public string? AppointmentSetSMS { get; set; }
        public string? PatientRegistrationSMS { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
