﻿using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class LaboratoryRequestList
    {
        [Key]
        public int Id {  get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public Patient Patient { get; set; }

        public int PatientId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public Employee Requester { get; set; }

        public int EmployeeId { get; set; }

        public bool Hematology { get; set; }

        public bool Chemistry { get; set; }

        public bool Serology { get; set; }

        public bool Urinalysis { get; set; }

        public bool Bacterology { get; set; }

        public bool Microscopy { get; set; }

        public bool StoolExamination { get; set; }
            
        public string? Status { get; set; } = "Pending";

        public int SatusCounter { get; set; } = 0;

        public int? MedicalRecoredId { get; set; }


        public MedicalRecord? MedicalRecord { get; set; }
        
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
