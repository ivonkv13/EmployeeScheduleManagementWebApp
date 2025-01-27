using EmployeeScheduleManagementWebApp.Server.Application.Interfaces;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using EmployeeScheduleManagementWebApp.Server.Shared.GenericRepository;
using EmployeeScheduleManagementWebApp.Server.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduleManagementWebApp.Server.Application.Services
{
    public class EmployeeService(IGenericRepository<Employee> employeeRepository, IUnitOfWork unitOfWork) : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository = employeeRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            var employee = await _employeeRepository
                .AsQueryable()
                .Where(e => e.Id == id)
                .Include(e => e.EmployeeRoles)
                .Include(e => e.Shifts)
                .FirstOrDefaultAsync();

            return employee;
        }
    }
}
