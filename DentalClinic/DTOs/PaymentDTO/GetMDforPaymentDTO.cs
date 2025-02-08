using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.PaymentDTO
{
    public class GetMDforPaymentDTO
    {
        public int PatientId { get; set; }
        public int MedicalRecordID { get; set; }
        public decimal Discount { get; set; }
        public int IssuedBy { get; set; }
        public DateTime MedicalRecordDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int[] ProcedureIDs { get; set; }
        public int[] Quantity { get; set; }
        public bool isCard { get; set; }

        public bool isPaid { get; set; }

        public Decimal? ConsultationFee { get; set; }

        public bool hasConsultationFee { get; set; }

        //public bool HasConsultationFee { get; set; }

        //public decimal? ConsultationPrice { get; set; }
        // List of LabTest objects to represent the lab tests and their prices
        public List<LabTest> LabTests { get; set; }
    }

    // LabTest class representing the lab test data
    public class LabTest
    {
        public string Name { get; set; }
        public bool IsTestSelected { get; set; }
        public decimal Price { get; set; }
    }
}

