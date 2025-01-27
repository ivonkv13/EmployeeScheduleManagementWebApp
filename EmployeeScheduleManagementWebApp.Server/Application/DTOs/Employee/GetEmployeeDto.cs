using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Application.DTOs
{
    public record GetEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeRole> EmployeeRoles { get; set; } = [];
        public ICollection<GetEmployeeShiftDto> Shifts { get; set; } = [];
    }
}