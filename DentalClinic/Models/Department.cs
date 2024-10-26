using System.ComponentModel.DataAnnotations;

namespace DentalClinic.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string? DepartmentName { get; set; }

        public List<Employee>? Employees { get; set; }

    }
}
