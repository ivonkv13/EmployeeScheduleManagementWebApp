using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeScheduleManagementWebApp.Server.Domain.Entities
{
    public class Shift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ShiftDate { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        
        [JsonIgnore]
        public Employee Employee { get; set; }

        [Required]
        public int EmployeeRoleId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
