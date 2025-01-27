using EmployeeScheduleManagementWebApp.Server.Application.DTOs;
using EmployeeScheduleManagementWebApp.Server.Application.Services;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
namespace EmployeeScheduleManagementWebApp.Server.Application.Interfaces
{
    public interface IShiftService
    {
        Task<List<Employee>> GetAllShiftsForTheWeekAsync(List<DateTime> daysOfTheWeeks);
        Task<Shift?> GetShiftByIdAsync(int id);
        Task<bool> UpdateShiftAsync(UpdateShiftDto shiftDto);
        Task<bool> DeleteShiftAsync(int id);
        Task<bool> CreateAsync(AssignShiftDto assignShiftDto);
        Task<ICollection<Shift>> GetShiftsForEmployeeAsync(int employeeId);
    }
}