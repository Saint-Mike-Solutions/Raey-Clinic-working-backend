namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class AddStoolExaminationDTO
    {

        public int? RequestedById { get; set; }

        public int? ReportedById { get; set; }

        public int? PatientId { get; set; }

        public string? Consistency { get; set; }

        public string? OP { get; set; }

        public string? Concentration { get; set; }

        public string? OccultBlood { get; set; }

        public int LabReqListId { get; set; }

    }
}
