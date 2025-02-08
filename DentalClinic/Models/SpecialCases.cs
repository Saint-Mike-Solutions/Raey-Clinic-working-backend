using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class SpecialCases
    {
        [Key]
        public int SpecialCaesId { get; set; }

        public string? SpecialCaesName { get; set; }

        public string? Description { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;
    }
}
