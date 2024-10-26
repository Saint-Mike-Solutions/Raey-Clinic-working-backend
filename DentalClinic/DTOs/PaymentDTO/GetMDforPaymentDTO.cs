using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.PaymentDTO
{
    public class GetMDforPaymentDTO
    {
            public int PatientId { get; set; }
            public decimal Discount { get; set; }
            public decimal SubTotal { get; set; }

            public int MedicalRecordID { get; set; }
            public int IssuedBy{ get; set; } 
            public decimal Total { get; set; }
            public DateTime MedicalRecordDate { get; set; }

            public int[] ProcedureIDs { get; set; }
            public int[] Quantity { get; set; }
            public bool isCard { get; set; }
    }
}

