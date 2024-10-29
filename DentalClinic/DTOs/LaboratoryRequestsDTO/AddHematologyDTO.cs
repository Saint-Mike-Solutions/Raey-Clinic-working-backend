namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class AddHematologyDTO
    {

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

        public int LabReqListId { get; set; }


    }
}
