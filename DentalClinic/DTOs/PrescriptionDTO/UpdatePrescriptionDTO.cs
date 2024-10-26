using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs
{
    public class UpdatePrescriptionDTO
    {
        public int PrescriptionID { get; set; }
        public string? DrugName { get; set; }

        public string? Strength { get; set; }

        public string? HowToUse { get; set; }

        public string? Frequency { get; set; }

        public string? Duration { get; set; }

        public string? Quantity { get; set; }

        public string? OtherInformation { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public Decimal? TotalPrice { get; set; }

        public string? Registrations { get; set; }

        public string? Qualification { get; set; }


        public bool? inPatient { get; set; }

        public string? Dosage { get; set; }

        public int EmployeeID { get; set; }

    }
}

