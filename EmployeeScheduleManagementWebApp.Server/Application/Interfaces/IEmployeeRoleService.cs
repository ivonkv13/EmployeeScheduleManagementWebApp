using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Application.Services
{
    public interface IEmployeeRoleService
    {
        Task<List<EmployeeRole>> GetEmployeeRoles(ICollection<int> employeeRoleIds);
    }
}