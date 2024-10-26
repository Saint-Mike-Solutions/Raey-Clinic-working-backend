namespace DentalClinic.DTOs.CreditDTO
{
    public class PayCreditDTO
    {
        public int PatientID { get; set; }
        public decimal PayingAmount { get; set; }
        public int PaymentIssuedBy { get; set; }
        public int PaymentTypeID { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
