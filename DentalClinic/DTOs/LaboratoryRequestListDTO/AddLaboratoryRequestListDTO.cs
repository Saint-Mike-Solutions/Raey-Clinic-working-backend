namespace DentalClinic.DTOs.LaboratoryRequestListDTO
{
    public class AddLaboratoryRequestListDTO
    {
        public bool Hematology { get; set; }

        public bool StoolExamination { get; set; }

        public bool Bacterology { get; set; }

        public bool Chemistry { get; set; }

        public bool Urinalysis { get; set; }

        public bool Serology {  get; set; }

        public bool Microscopy { get; set; }

        public int PatientId { get; set; }

        public int EmployeeId { get; set; }

        public string Status { get; set; } = "Pending";
    }
}
