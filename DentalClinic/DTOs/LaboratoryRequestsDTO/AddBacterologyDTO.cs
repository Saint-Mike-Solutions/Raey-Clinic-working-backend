using DentalClinic.Models;

namespace DentalClinic.DTOs.LaboratoryRequestsDTO
{
    public class AddBacterologyDTO
    {

        public int? RequestedById { get; set; }

        public int? ReportedById { get; set; }

        public int? PatientId { get; set; }
        public string? Sample { get; set; }

        public string? Koh { get; set; }

        public string? GramStain { get; set; }

        public string? WetFilm { get; set; }

        //public int? AFBId { get; set; }
        //public AFB? AFB { get; set; }


        public string? Culture { get; set; }


        public string? AFBOne { get; set; }

        public string? AFBTwo { get; set; }

        public string? AFBThree { get; set; }

        public int LabReqListId { get; set; }

    }
}
