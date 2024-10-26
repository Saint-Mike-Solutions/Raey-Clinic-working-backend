namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class AddMicroscopyDTO
    {
        public int? RequestedById { get; set; }

        public int? ReportedById { get; set; }

        public int? PatientId { get; set; }
        public string? EpitCells { get; set; }

        public string? MWbc { get; set; }

        public string? Rbc { get; set; }

        public string? casts { get; set; }

        public string? crystals { get; set; }

        public string? Bacteria { get; set; }

        public string? Hcg { get; set; }
    }
}
