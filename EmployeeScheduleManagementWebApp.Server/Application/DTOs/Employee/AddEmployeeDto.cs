using System.ComponentModel.DataAnnotations;

namespace EmployeeScheduleManagementWebApp.Server.Application.DTOs
{
    public record AddEmployeeDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public ICollection<int> RoleIds { get; set; } = [];
    }
}
