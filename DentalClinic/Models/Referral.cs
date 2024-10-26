using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Referral
    {

        [Key]
        public int Id { get; set; }

        public string? ReferalTo { get; set; }

        public DateTime? ReferralDate { get; set; } = DateTime.Now;

        public string? ReferalNumber { get; set;}

        public string? CardNumber { get; set;}

        public int? ReferredBy { get; set; }  // This allows the EmployeeId to be null if needed
        public Employee? Employee { get; set; }

        // Foreign key for Patient
        public int PatientId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public Patient? Patient { get; set; }

        public string? HealthProblemIdentified { get; set; }

        public string? InvestigationDoneAndResult { get; set; }

        public string? AnyActionTaken { get; set; }

        public string? ReasonsForReferral { get; set; }

        public string? ReferralFeedback { get; set; }



    }
}
