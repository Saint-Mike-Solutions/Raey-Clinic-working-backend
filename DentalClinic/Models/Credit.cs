using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class Credit
    {
        [Key]
        public int CreditID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
        public decimal TotalCreditAmount {get; set; }
        [ForeignKey("Employee")]
        public int IssuedBy { get; set; }
        public Employee? Employee { get; set; }
        public decimal Paid { get; set; }
        public decimal UnPaid { get; set; }
    


        public DateTime ChargeDate { get; set; }

    }
}
