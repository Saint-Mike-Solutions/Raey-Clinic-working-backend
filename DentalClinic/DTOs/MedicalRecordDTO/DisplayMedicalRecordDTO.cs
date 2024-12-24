using DentalClinic.Models;

namespace DentalClinic.DTOs.MedicalRecordDTO
{
    public class DisplayMedicalRecordDTO
    {
        public int Medical_RecordID { get; set; }
        public int PatientId { get; set; }
        public int TreatedById { get; set; }
        public string TreatedByName { get; set; } = string.Empty;
        public string PrescribedMedicinesandNotes { get; set; } = string.Empty;
        public string ReferalsList { get; set; } = string.Empty;
        public List<Procedure>? Procedures { get; set; }
        public int DiscountPercent { get; set; }

        public decimal TotalAmount { get; set; }
        public bool isCard { get; set; }
        public bool IsPaid { get; set; } = false;

        public int[]? ProceduresIDs { get; set; }

        public int[]? Quantity { get; set; }

        public decimal SubTotalAmount { get; set; }
        public DateTime date { get; set; }

        public bool IsHematology { get; set; }
        public bool IsSerology { get; set; }
        public bool IsStoolExamination { get; set; }
        public bool IsMicroscopy { get; set; }
        public bool IsChemistry { get; set; }
        public bool IsBacterology { get; set; }
        public bool IsUrinalysis { get; set; }
    }
}
