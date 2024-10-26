namespace DentalClinic.DTOs.PaymentDTO
{
    public class MakePaymentMedRecDTO
    {
        public int MedicalRecordID { get; set; }

        public int PaymentType { get; set; }

        public int IssuedByID { get; set; }

        public int[] ProcedureIDs { get; set; }
        public int[] Quantity { get; set; }

        public int PatientID { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public int Discount { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public bool IsCredit { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? MobileBanking { get; set; }

        public string? ImageAttachment { get; set; }
    }
}
