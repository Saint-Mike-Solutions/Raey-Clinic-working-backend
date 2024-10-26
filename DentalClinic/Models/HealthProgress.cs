using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class HealthProgress
    {
        [Key]
        public int ProgressID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        //[ForeignKey("Employee")]
        //public int? AdministeredBY { get; set; }
        [ForeignKey("Employee")]
        public int? AdministeredById { get; set; }
        public Employee? Employee { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;

        public double Weight { get; set; }  

        public string BloodPressure { get; set; } = string.Empty;

        public string OtherVitalSigns { get; set; } = string.Empty;

        public string NotesOnProgress { get; set; } = string.Empty;

        public string Miko { set; get; } = string.Empty;

        [JsonIgnore]
        public Patient? Patient { get; set; }
    }

}
