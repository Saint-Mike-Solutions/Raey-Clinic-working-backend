namespace DentalClinic.DTOs.SMSSettingDTO
{
    public class SMSSettingAddDTO
    {
        public string SMSApi { get; set; } = string.Empty;

        public string DeviceId { get; set; } = string.Empty;

        public string LoanExpireSMS { get; set; } = string.Empty;

        public string AppointmentSetSMS { get; set; } = string.Empty;
        public string PatientRegistrationSMS { get; set; } = string.Empty;
    }
}
