namespace DentalClinic.DTOs.RoleDTO
{
    public class UpdateRoleDTO
    {
        public int RoleIds { get; set; }
        public string RoleName { get; set; }

        public bool CanControlPayment { get; set; }
        public bool CanGenerateReport { get; set; }
        public bool CanMagEmploy { get; set; }
        public bool CanManageAppointment { get; set; }
        public bool CanManageMedicalRecord { get; set; }

        public bool CanManagePatient { get; set; }

        public bool CanManageSetting { get; set; }

        public bool CanManageUserPrivalage { get; set; }

    }
}
