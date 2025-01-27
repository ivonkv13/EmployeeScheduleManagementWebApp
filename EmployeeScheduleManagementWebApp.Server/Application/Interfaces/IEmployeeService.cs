using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeAsync(int id);
    }
}
