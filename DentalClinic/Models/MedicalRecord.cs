using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Medical_RecordID { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;

        //public string LabTests { get; set; } = string.Empty;

        public string PrescribedMedicinesandNotes { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonIgnore]
        public Patient? Patient { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        public string ReferalList { get; set; } = string.Empty;
        //[System.Text.Json.Serialization.JsonIgnore]

        public List<Procedure>? Procedures { get; set; }

        [ForeignKey("TreatedBy")]
        public int? TreatedById { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public Employee? TreatedBy { get; set; }
        
        public int DiscountPercent { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; } = false; 

        public string ProcedureIDs { set; get; } = string.Empty;

        public string Quantities { get; set; } = string.Empty;

        public decimal SubTotalAmount { get; set; }

        public bool IsCard { get; set; } = false;

        public bool IsHematology { get; set; }
        public bool IsSerology { get; set; }
        public bool IsStoolExamination { get; set; }
        public bool IsMicroscopy { get; set; }
        public bool IsChemistry { get; set; }
        public bool IsBacterology { get; set; }
        public bool IsUrinalysis { get; set; }

        public static implicit operator List<object>(MedicalRecord v)
        {
            throw new NotImplementedException();
        }
    }
}
