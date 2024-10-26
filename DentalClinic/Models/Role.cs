using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DentalClinic.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public String RoleName { get; set; } = null!;

        //public UserAccount UserAccount { get; set; }
        public bool CanControlPayment { get; set; } = false;
        public bool CanGenerateReport { get; set; } = false;
        public bool CanMagEmploy { get; set; } = false;
        public bool CanManageAppointment { get; set; } = false;
        public bool CanManageMedicalRecord { get; set; } = false;

        public bool CanManagePatient { get; set; } = false;

        public bool CanManageSetting { get; set; } = false;

        public bool CanManageUserPrivalage { get; set; } = false;

        [System.Text.Json.Serialization.JsonIgnore]
        public List<UserAccount> UserAccounts { get; set; }
    }
}
    