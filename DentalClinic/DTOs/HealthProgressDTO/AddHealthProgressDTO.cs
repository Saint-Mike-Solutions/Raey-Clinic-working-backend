namespace DentalClinic.DTOs.HealthProgressDTO
{
    public class AddHealthProgressDTO
    {
        public int PatientID { get; set; }
        public int AdministeredBY { get; set; }
        public double Weight { get; set; }
        public string BloodPressure { get; set; } = string.Empty;
        public string OtherVitalSigns { get; set; } = string.Empty;
        public string NotesOnProgress { get; set; } = string.Empty;
    }
}
