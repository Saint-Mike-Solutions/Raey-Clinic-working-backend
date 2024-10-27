using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class CompanyLabPrices
    {
        [Key]
        public int CompanyLabPriceId { get; set; } // Corrected the property name to use PascalCase

        public Decimal StoolExamPrice { get; set; }

        public Decimal BacterologyPrice { get; set; }

        public Decimal MicroscopyPrice { get; set; }

        public Decimal UrinalysisPrice { get; set; }

        public Decimal HematologyPrice { get; set; }

        public Decimal ChemistryPrice { get; set; }

        public Decimal SerologyPrice { get; set; }
    }
}
