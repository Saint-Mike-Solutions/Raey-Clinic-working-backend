using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.DTOs.CreditDTO
{
    public class DisplayCreditHistoryDTO
    {
        public int ID { get; set; }
        public string PatientName { get; set; }
        public decimal Paid { get; set; }

        public DateTime CreateAt { get; set; }

        public int PaymentType { get; set; }


        public string IssuedBy { get; set; }
    }
}
