using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeScheduleManagementWebApp.Server.Domain.Entities
{
    public class EmployeeRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; } = [];
    }
}
