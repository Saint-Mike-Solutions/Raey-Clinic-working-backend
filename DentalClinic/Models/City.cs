using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;



    }
}
