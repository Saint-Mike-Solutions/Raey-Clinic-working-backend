using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.DTOs.ProcedureDTO
{
    public class AddProcedureDTO
    {
        public string ProcedureName { get; set; } = string.Empty;

        public decimal? Price { get; set; }

        public string pricingReason { get; set; } = string.Empty;

        public string pricingDescription { get; set; } = string.Empty;
    }
}
