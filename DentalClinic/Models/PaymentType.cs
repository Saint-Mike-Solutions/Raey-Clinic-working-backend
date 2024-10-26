namespace DentalClinic.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string PaymentName { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Payment>? Payments { get; set; }

        public List<CreditPaymentRecord>? CreditPaymentRecord { get; set; }
    }
}
