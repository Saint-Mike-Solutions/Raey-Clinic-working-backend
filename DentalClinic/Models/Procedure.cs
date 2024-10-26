using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class Procedure
    {
        public int ProcedureID { get; set; }

        public string ProcedureName { get; set; } = string.Empty;

        [ForeignKey("PricingReason")]
        [System.Text.Json.Serialization.JsonIgnore]

        public int PricingReasonID { get; set; } 
        public PricingReason? PricingReason { get; set;}

        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("PricingDescription")]
        public int PricingDescriptionID { get; set; }

        public PricingDescription? PricingDescription { get; set; }

        public decimal ? Price { get; set; }

        public static implicit operator string?(Procedure? v)
        {
            throw new NotImplementedException();
        }
    }
}
