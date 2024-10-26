using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        public string? DrugName { get; set; }

        public string? Strength { get; set; }

        public string? HowToUse { get; set; }

        public string? Frequency { get; set; }

        public string? Dosage { get; set; }
        public string? Duration { get; set; }

        public bool? inPatient { get; set; }

        public string? Quantity { get; set; }

        public string? OtherInformation { get; set; }

        public string? Qualification { get; set; }

        public string? Registrations { get; set; }

        public Decimal? TotalPrice { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Employee? Emp { get; set; }

        public Patient? Patient { get; set; }



    }
}
