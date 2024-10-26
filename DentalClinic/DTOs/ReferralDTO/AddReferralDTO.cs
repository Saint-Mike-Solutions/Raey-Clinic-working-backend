using DentalClinic.Models;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.ReferralDTO
{
    public class AddReferralDTO
    {

        public string? ReferalTo { get; set; }

        public string? ReferalNumber { get; set; }

        public string? CardNumber { get; set; }

        public int? ReferredBy { get; set; }  // This allows the EmployeeId to be null if needed

        // Foreign key for Patient
        public int PatientId { get; set; }

        public string? HealthProblemIdentified { get; set; }

        public string? InvestigationDoneAndResult { get; set; }

        public string? AnyActionTaken { get; set; }

        public string? ReasonsForReferral { get; set; }

        public string? ReferralFeedback { get; set; }
    }
}
