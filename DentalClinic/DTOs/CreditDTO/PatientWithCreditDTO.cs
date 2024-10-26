namespace DentalClinic.DTOs.CreditDTO
{
    public class PatientWithCreditDTO
    {
        public int Id { get; set; }
        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public string PatientAdress { get; set; }

        public int Age { get; set; }

        public decimal CreditAmount { get; set; }
        public string CreditIssuedByName { get; set; }

        public int DaysUntilLoanExpire { get; set; }
    }
}
