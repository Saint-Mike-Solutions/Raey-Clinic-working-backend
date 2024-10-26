using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class AFB
    {
        [Key]
        public int Id { get; set; }

        public string? One { get; set; }

        public string? Two { get; set; }

        public string? Three { get; set; }

    }
}
