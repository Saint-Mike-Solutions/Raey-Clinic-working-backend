namespace DentalClinic.DTOs.ProcedureDTO
{
    public class UpdateProcedureDTO
    {
        public int ID { get; set; }
        public string ProcedureName { get; set; } = string.Empty;

        public decimal? Price { get; set; }

        public string pricingReasonUpdate { get; set; } = string.Empty;

        public string pricingDescriptionUpdate { get; set; } = string.Empty;
    }
}
