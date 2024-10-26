using DentalClinic.Models;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.ReferralDTO
{
    public class UpdateReferralDTO
    {
        public int Id { get; set; }

        public string? ReferalTo { get; set; }

        public DateTime? ReferralDate { get; set; } = DateTime.Now;

        public string? ReferalNumber { get; set; }

        public string? CardNumber { get; set; }


        // Foreign key for Patient


        public string? HealthProblemIdentified { get; set; }

        public string? InvestigationDoneAndResult { get; set; }

        public string? AnyActionTaken { get; set; }

        public string? ReasonsForReferral { get; set; }

        public string? ReferralFeedback { get; set; }
    }
}
