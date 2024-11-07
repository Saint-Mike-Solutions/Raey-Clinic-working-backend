using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class LaboratoryRequests
    {
        [Key]
        public int Id { get; set; }

        public Hematology? Hematology { get; set; }

        public Urinalysis? Urinalysis { get; set; }

        public Serology? Serology { get; set; }

        public StoolExamination? StoolExamination { get; set; }

        public Microscopy? Microscopy { get; set; }

        public Chemistry? Chemistry { get; set; }

        public Bacterology? Bacterology { get; set; }

        //public List<LaboratoryRequestList>? LabrequestLists { get; set; }
        
        public int? PatientId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore]

        public Patient? Patient { get; set; }

        public int? RequestedById { get; set; }

        public Employee? RequestedBy { get; set; }

        public int? ReportedById { get; set; }

        public Employee? ReportedBy { get; set; }

        public DateTime? ReportedDate { get; set; } = DateTime.Now;

        public bool isPaid { get; set; } = false;

        public static implicit operator List<object>(LaboratoryRequests v)
        {
            throw new NotImplementedException();
        }
    }
}
