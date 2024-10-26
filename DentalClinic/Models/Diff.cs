using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Diff
    {
        [Key]
        public int Id { get; set; }

        public string? N { get; set; }

        public string? E { get; set; }

        public string? B { get; set; }

        public string? L { get; set; }

        public string? M { get; set; }  



    }
}
