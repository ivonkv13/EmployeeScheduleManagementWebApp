using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeScheduleManagementWebApp.Server.Domain.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public ICollection<EmployeeRole> EmployeeRoles { get; set; } = [];

        public ICollection<Shift> Shifts { get; set; } = [];
    }
}
