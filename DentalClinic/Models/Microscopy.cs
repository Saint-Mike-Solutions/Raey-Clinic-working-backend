using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Microscopy
    {
        [Key]
        public int Id { get; set; }
        
        public string? EpitCells { get; set; }

        public string? Wbc {  get; set; }

        public string? Rbc { get; set; }

        public string? casts { get; set; }

        public string? crystals { get; set; }

        public string? Bacteria { get; set; }

        public string? Hcg { get; set; }

        public int LaboratoryRequestId { get; set; }  // Foreign key for the Laboratory Request.
        public LaboratoryRequests? LaboratoryRequest { get; set; }  // Navigation property back to LaboratoryRequests.
    }
}
