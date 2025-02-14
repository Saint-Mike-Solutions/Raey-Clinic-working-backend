using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Medical_RecordID { get; set; }

        // Foreign key reference to Patient
        public int PatientId { get; set; }
        //[ForeignKey("PatientId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public Patient? Patient { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string PrescribedMedicinesandNotes { get; set; } = string.Empty;
        public string ReferalList { get; set; } = string.Empty;

        // One-to-Many Relationship with Procedure
        public List<Procedure>? Procedures { get; set; }

        // Foreign key for the employee who treated the patient
        public int? TreatedById { get; set; }
        //[ForeignKey("TreatedById")]
        [System.Text.Json.Serialization.JsonIgnore]
        public Employee? TreatedBy { get; set; }

        public int DiscountPercent { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; } = false;

        public string ProcedureIDs { get; set; } = string.Empty;
        public string Quantities { get; set; } = string.Empty;

        public decimal SubTotalAmount { get; set; }
        public bool IsCard { get; set; } = false;

        // Lab tests
        public bool IsHematology { get; set; }
        public bool IsSerology { get; set; }
        public bool IsStoolExamination { get; set; }
        public bool IsMicroscopy { get; set; }
        public bool IsChemistry { get; set; }
        public bool IsBacterology { get; set; }
        public bool IsUrinalysis { get; set; }

        public bool HasConsultationFee { get; set; }
        public decimal? ConsultationPrice { get; set; }

        public LaboratoryRequests? LaboratoryRequest { get; set; }

        public Payment? Payment { get; set; }
        
        public LaboratoryRequestList? LaboratoryRequestsList { get; set; }


    }
}
