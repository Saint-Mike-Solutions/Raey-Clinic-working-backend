using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        //public List<Procedure>? Procedures { get; set; }
        public decimal Discount { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
        public int? Tax { get; set; } = 0;
        public decimal SubTotal { get; set; }
        [ForeignKey("Employee")]
        public int IssuedByID { get; set; }
        public Employee? Employee { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("PaymentType")]
        public int? PaymentTypeID { get; set; }
        public PaymentType? PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsCredit { get; set; } = false;

        public string? MobileBanking { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? ImageAttachment { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }
         
        }
    }

