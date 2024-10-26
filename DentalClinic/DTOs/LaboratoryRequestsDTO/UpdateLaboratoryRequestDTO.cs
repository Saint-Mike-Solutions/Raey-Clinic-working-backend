using DentalClinic.Models;

namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class UpdateLaboratoryRequestDTO
    {
        public int? LabReportId { get; set; }  // Changed to match the naming convention

        public int? RequestedById { get; set; }

        public int? ReportedById { get; set; }

        public int? PatientId { get; set; }

        public string? Wbc { get; set; }

        public string? HemaN { get; set; }

        public string? HemaE { get; set; }

        public string? HemaB { get; set; }

        public string? HemaL { get; set; }

        public string? HemaM { get; set; }

        public string? Hgb { get; set; }

        public string? Hct { get; set; }

        public string? Esr { get; set; }

        public string? Platletes { get; set; }

        public string? BloodGroup { get; set; }

        public string? Rh { get; set; }

        public string? BloodFilm { get; set; }

        public int? DiffId { get; set; }

        // Urinalysis
        public string? Color { get; set; }

        public string? Appearance { get; set; }

        public string Ph { get; set; }

        public string? Sg { get; set; }

        public string? Protein { get; set; }

        public string? Glucose { get; set; }

        public string? Leukocyte { get; set; }

        public string? Ketone { get; set; }

        public string? Bilirubin { get; set; }

        public string? Urobilingen { get; set; }

        public string? Blood { get; set; }

        // Serology
        public string? Vdlr { get; set; }

        public string? WidalH { get; set; }

        public string? WeilFelix { get; set; }

        public string? HbsAg { get; set; }

        public string? HcvAb { get; set; }

        public string? Aso { get; set; }

        public string? Rf { get; set; }

        public string? HPyloryAg { get; set; }

        public string? HPyloryAb { get; set; }

        // Stool Examination
        public string? Consistency { get; set; }

        public string? OP { get; set; }

        public string? Concentration { get; set; }

        public string? OccultBlood { get; set; }

        // Chemistry
        public string? FbsRbs { get; set; }

        public string? Sgot { get; set; }

        public string? Sgpt { get; set; }

        public string? AlkalinePhosphates { get; set; }

        public string? BilirubinTotal { get; set; }

        public string? BilirubinDirect { get; set; }

        public string? Urea { get; set; }

        public string? Bun { get; set; }

        public string? Creatine { get; set; }

        public string? UricAcid { get; set; }

        public string? TotalAcid { get; set; }

        public string? TotalProtein { get; set; }

        public string? Triglycerides { get; set; }

        public string? cholesterol { get; set; }

        public string? Hdl { get; set; }

        public string? Ldl { get; set; }

        // Microscopy
        public string? EpitCells { get; set; }

        public string? MWbc { get; set; }

        public string? Rbc { get; set; }

        public string? casts { get; set; }

        public string? crystals { get; set; }

        public string? Bacteria { get; set; }

        public string? Hcg { get; set; }

        // Bacterology
        public string? Sample { get; set; }

        public string? Koh { get; set; }

        public string? GramStain { get; set; }

        public string? WetFilm { get; set; }

        public int? AFBId { get; set; }

        public AFB? AFB { get; set; }

        public string? Culture { get; set; }

        public string? AFBOne { get; set; }

        public string? AFBTwo { get; set; }

        public string? AFBThree { get; set; }
    }
}
