using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Urinalysis
    {
        [Key]
        public int Id { get; set; }

        public string? Color { get; set; }

        public string? Appearance { get; set; }

        public string Ph { get; set; }

        public string? Sg { get; set; }

        public string? Protein { get; set; }

        public string? Glucose { get; set; }

        public string? Leukocyte { get; set; }

        public string? Ketone { get; set; }

        public string? Bilirubin { get; set; }

        public string? Urobilingen { get; set; }

        public string? Blood { get; set; }

    }
}
