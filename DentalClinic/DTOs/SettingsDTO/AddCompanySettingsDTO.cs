namespace DentalClinic.DTOs.SettingsDTO
{
    public class AddCompanySettingsDTO
    {

        public string CompanyName { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public int LoanExpireAfter { get; set; }

        public int CardExpireAfter { get; set; }

        public int EarlyReminderDate { get; set; }
        public int AppointmentDuration { get; set; }

        public decimal MaximumLoanAmount { get; set; }
        public int NumberOfBranches { get; set; }
        public int EarlyReminderForLoan { get; set; }
    }
}
