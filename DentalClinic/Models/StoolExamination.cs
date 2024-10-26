using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class StoolExamination
    {
        [Key]
        public int Id { get; set; }

        public string? Consistency {  get; set; }

        public string? OP { get; set; }

        public string? Concentration { get; set; }

        public string? OccultBlood { get; set; }


    }
}
