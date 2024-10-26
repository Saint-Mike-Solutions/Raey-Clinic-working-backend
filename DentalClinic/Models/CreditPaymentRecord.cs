using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class CreditPaymentRecord
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
        
        public decimal Paid { get; set; }

        public DateTime CreateAt { get; set; }

        [ForeignKey("PaymentTypes")]
        public int PaymentType { get; set; }
        
        public PaymentType? PaymentTypes { get; set; }

        [ForeignKey("Employee")]
        public int IssuedBy { get; set; }
        public Employee? Employee { get; set; }
    }
}
