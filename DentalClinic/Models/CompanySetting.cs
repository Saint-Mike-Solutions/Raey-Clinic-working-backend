using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class CompanySetting
    {
        [Key]
        public int CompanySettingID { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public int LoanExpireAfter { get; set; }

        public int CardExpireAfter { get; set; }

        public int EarlyReminderDate { get; set; }

        public decimal MaximumLoanAmount { get; set; }

        public int AppointmentDuration { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set;} = DateTime.Now;

        public int EarlyReminderForLoan { get; set; }

        public int NumberOfBranches { get; set; }

    }
}
