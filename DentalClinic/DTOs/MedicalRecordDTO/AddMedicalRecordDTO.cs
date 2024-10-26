using DentalClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic.DTOs.MedicalRecordDTO
{
    public class AddMedicalRecordDTO
    {
        public int PatientId { get; set; }
        public int TreatedByID { get; set; } 

        public string PrescribedMedicinesandNotes { get; set; } = string.Empty;

        public string ReferalList { get; set; } = string.Empty;

        public int[]? ProceduresIDs { get; set; }

        public int[]? Quantity { get; set; }

        public int DiscountPercent { get; set; }

 


    }
}
