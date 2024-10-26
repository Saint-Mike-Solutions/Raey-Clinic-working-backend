// A DTO to send the PricingReasonName and PricingDescriptionName of the Procedures 
using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.DTOs.ProcedureDTO
{
    public class DisplayProcedureDTO
    {
        public int ProcedureID { get; set; }
        public string ProcedureName { get; set; } = string.Empty;
        public string PricingReasonName { get; set; } = string.Empty;
        public string PricingDescriptionName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
    }
}
