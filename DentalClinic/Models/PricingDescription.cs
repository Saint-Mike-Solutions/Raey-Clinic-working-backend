using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class PricingDescription
    {
        [Key]
        //[System.Text.Json.Serialization.JsonIgnore]
        public int PricingDescriptionId { get; set; }
        public string pricingDescription { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Procedure>? Procedures { get; set; }
    }
}
