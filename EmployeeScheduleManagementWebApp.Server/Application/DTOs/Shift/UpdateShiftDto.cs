using System.ComponentModel.DataAnnotations;

namespace EmployeeScheduleManagementWebApp.Server.Application.Interfaces
{
    public record UpdateShiftDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime ShiftDate { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int EmployeeRoleId { get; set; }
    }
}