using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class PricingReason
    {
        [Key]
        //[System.Text.Json.Serialization.JsonIgnore]
        public int PricingReasonID { get; set; }  
        public string PricingReasonName { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Procedure>? Procedures { get; set; }
    }
}
