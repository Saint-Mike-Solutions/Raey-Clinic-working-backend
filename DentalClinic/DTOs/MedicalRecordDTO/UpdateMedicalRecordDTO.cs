namespace DentalClinic.DTOs.MedicalRecordDTO
{
    public class UpdateMedicalRecordDTO
    {
        public int MedicalRecordID { get; set; }
        public int PatientId { get; set; }
        public int TreatedByID { get; set; }

        public string PrescribedMedicinesandNotes { get; set; } = string.Empty;

        public string ReferalList { get; set; } = string.Empty;
        public int[]? ProceduresNew { get; set; }

        public int[]? QuantitiesNew { get; set; }

        public int DiscountPercent { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubTotalAmount { get; set; }
    }
}
