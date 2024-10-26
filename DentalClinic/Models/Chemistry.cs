using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Chemistry
    {
        [Key]
        public int Id { get; set; }
    
        public string? FbsRbs { get; set; }

        public string? Sgot {  get; set; }

        public string? Sgpt { get; set; }

        public string? AlkalinePhosphates { get; set; }

        public string? BilirubinTotal { get; set; }

        public string? BilirubinDirect {  get; set; }

        public string? Urea {  get; set; }

        public string? Bun {  get; set; }

        public string? Creatine { get; set; }

        public string? UricAcid { get; set; }

        public string? TotalAcid { get; set; }

        public string? TotalProtein { get; set; }

        public string? Triglycerides { get; set; }

        public string? cholesterol { get; set; }

        public string? Hdl { get; set; }

        public string? Ldl   { get; set; }


    }
}
