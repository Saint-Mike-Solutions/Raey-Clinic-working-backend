using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.DTOs.CreditDTO
{
    public class ChargeCreditDTO
    {
        public int PatientID { get; set; }
        public decimal CreditAmount { get; set; }
        public int IssuedBy { get; set; }

        public int PaymentType { get; set; }
        public DateTime DateTime { get; set; }
    }
}
