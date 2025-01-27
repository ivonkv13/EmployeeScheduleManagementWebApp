using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using EmployeeScheduleManagementWebApp.Server.Shared.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduleManagementWebApp.Server.Application.Services
{
    public class EmployeeRoleService(IGenericRepository<EmployeeRole> employeeRolesRepository) : IEmployeeRoleService
    {
        private readonly IGenericRepository<EmployeeRole> _employeeRolesRepository = employeeRolesRepository;

        public async Task<List<EmployeeRole>> GetEmployeeRoles(ICollection<int> employeeRoleIds)
        {
            var employeeRoles = await _employeeRolesRepository
                .AsQueryable()
                .Where(eRole => employeeRoleIds.Contains(eRole.Id))
                .ToListAsync();

            return employeeRoles;
        }
    }
}
