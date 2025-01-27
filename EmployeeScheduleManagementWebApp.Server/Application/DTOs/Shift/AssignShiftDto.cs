using System.ComponentModel.DataAnnotations;

namespace EmployeeScheduleManagementWebApp.Server.Application.Services
{
    public record AssignShiftDto
    {
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