namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class AddSerologyDTO
    {

        public int? RequestedById { get; set; }

        public int? ReportedById { get; set; }

        public int? PatientId { get; set; }

        public string? Vdlr { get; set; }

        public string? WidalH { get; set; }

        public string? WeilFelix { get; set; }

        public string? HbsAg { get; set; }

        public string? HcvAb { get; set; }

        public string? Aso { get; set; }

        public string? Rf { get; set; }

        public string? HPyloryAg { get; set; }

        public string? HPyloryAb { get; set; }

        public int LabReqListId { get; set; }

    }
}
