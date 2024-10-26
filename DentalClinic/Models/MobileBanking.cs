using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class MobileBanking
    {
        [Key]
        public int MobileBankingID { get; set; }

        public string? MobileBankingName { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public List<Payment>? Payments { get; set; }
    }
}
