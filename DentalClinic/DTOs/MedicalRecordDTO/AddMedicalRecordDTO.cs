﻿using DentalClinic.Models;
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

        public bool HasConsultationFee { get; set; }

        public decimal? ConsultationPrice { get; set; }

        public bool Hematology { get; set; }

        public bool Chemistry { get; set; }

        public bool Serology { get; set; }

        public bool Urinalysis { get; set; }

        public bool Bacterology { get; set; }

        public bool Microscopy { get; set; }

        public bool StoolExamination { get; set; }




    }
}
