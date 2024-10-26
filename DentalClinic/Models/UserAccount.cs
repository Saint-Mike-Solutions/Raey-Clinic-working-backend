using DentalClinic.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinic.Models
{
    public class UserAccount : IAuditableEntity
    {
        [Key]
        public int UserAccountId { get; set; }
        public string UserName { get; set; } = null!;

        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
        //public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public int EmployeeId { get; set; } // Foreign key to Employee
        [System.Text.Json.Serialization.JsonIgnore]

        public Employee Employee { get; set; } // Navigation property to Employee
        public DateTime CreatedAt { get ; set ; }
        public DateTime UpdatedAt { get ; set ; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
