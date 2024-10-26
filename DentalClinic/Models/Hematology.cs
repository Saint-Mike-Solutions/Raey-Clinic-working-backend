using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Hematology
    {
        [Key]
        public int Id { get; set; }

        public string? Wbc { get; set; }

        public string? Hgb { get; set; }

        public string? Hct { get; set; }

        public string? Esr { get; set; }

        public string? Platletes { get; set; }

        public string? BloodGroup { get; set; }

        public string? Rh { get; set; }

        public string? BloodFilm { get; set; }


        public int? DiffId { get; set; }

        public Diff? Diff { get; set;}



    }
}
