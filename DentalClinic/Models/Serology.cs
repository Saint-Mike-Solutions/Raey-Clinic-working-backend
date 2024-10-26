using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Serology
    {

        [Key]
        public int Id { get; set; } 

        public string? Vdlr {  get; set; }

        public string? WidalH {  get; set; }

        public string? WeilFelix { get; set; }

        public string? HbsAg {  get; set; }

        public string? HcvAb { get; set; }

        public string? Aso { get; set; }

        public string? Rf {  get; set; }

        public string? HPyloryAg { get; set; }

        public string? HPyloryAb { get; set; }


    }

}
