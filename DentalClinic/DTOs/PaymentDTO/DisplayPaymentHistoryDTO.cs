using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.PaymentDTO
{
    public class DisplayPaymentHistoryDTO
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int PatientID { get; set; }
        public int? Tax { get; set; } = 0;
        public decimal SubTotal { get; set; }
        public int IssuedByID { get; set; }
        public decimal Total { get; set; }
        public int? PaymentTypeID { get; set; }
        public DateTime PaymentDate { get; set; }

        public bool IsCredit { get; set; } = false;

        public string? MobileBanking { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? ImageAttachment { get; set; }

        public List<ProcedureQuantityDTO>? ProcedureQuantity { get; set; }

    }
}
