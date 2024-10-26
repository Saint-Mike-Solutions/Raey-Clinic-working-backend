using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Bacterology
    {
        [Key]
        public int Id { get; set; }
        
        public string? Sample { get; set; }

        public string? Koh {  get; set; }

        public string? GramStain { get; set; }

        public string? WetFilm { get; set; }

        public int? AFBId { get; set; }
        public AFB? AFB { get; set; }

        public string? Culture { get; set; }


    }
}
