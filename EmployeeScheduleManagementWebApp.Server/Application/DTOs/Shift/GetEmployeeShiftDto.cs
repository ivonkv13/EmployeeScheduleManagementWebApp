namespace EmployeeScheduleManagementWebApp.Server.Application.DTOs
{
    public record GetEmployeeShiftDto
    {
        public DateTime ShiftDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int EmployeeRoleId { get; set; }

    }
}