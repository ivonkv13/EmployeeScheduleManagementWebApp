using AutoMapper;
using EmployeeScheduleManagementWebApp.Server.Application.Interfaces;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using EmployeeScheduleManagementWebApp.Server.Shared.GenericRepository;
using EmployeeScheduleManagementWebApp.Server.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduleManagementWebApp.Server.Application.Services
{
    public class ShiftService(
        IGenericRepository<Shift> shiftRepository,
        IGenericRepository<Employee> employeeRepository,
        IGenericRepository<EmployeeRole> employeeRoleRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IShiftService
    {
        private readonly IGenericRepository<Shift> _shiftRepository = shiftRepository;
        private readonly IGenericRepository<Employee> _employeeRepository = employeeRepository;
        private readonly IGenericRepository<EmployeeRole> _employeeRoleRepository = employeeRoleRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<List<Employee>> GetAllShiftsForTheWeekAsync(List<DateTime> daysOfTheWeek)
        {
            var dates = daysOfTheWeek.Select(d => d.Date).ToList();

            var allEmployees = await _employeeRepository.AsQueryable()
                .Include(e => e.Shifts) 
                .ThenInclude(s => s.EmployeeRole) 
                .ToListAsync();

            foreach (var employee in allEmployees)
            {
                employee.Shifts = employee.Shifts
                    .Where(shift => dates.Contains(shift.ShiftDate.Date))
                    .ToList();
            }

            return allEmployees;
        }

        public async Task<Shift?> GetShiftByIdAsync(int id)
        {
            return await _shiftRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateShiftAsync(UpdateShiftDto updateShiftDto)
        {

            var employee = await _employeeRepository.GetByIdAsync(updateShiftDto.EmployeeId);
            
            #region Should be moved in a validator class
            if (employee == null)
            {
                return false;
                throw new ArgumentException("Invalid employee ID.");
            }

            var role = await _employeeRoleRepository.GetByIdAsync(updateShiftDto.EmployeeRoleId);
            if (role == null)
            {
                return false;

                throw new ArgumentException("Invalid role ID.");
            }

            if (updateShiftDto.EndTime <= updateShiftDto.StartTime)
            {
                return false;

                throw new ArgumentException("End time must be after start time.");
            }

            var overlappingShift = await _shiftRepository.AsQueryable()
                .Where(s => s.EmployeeId == updateShiftDto.EmployeeId &&
                            s.ShiftDate == updateShiftDto.ShiftDate &&
                            s.StartTime < updateShiftDto.EndTime &&
                            s.EndTime > updateShiftDto.StartTime)
                .FirstOrDefaultAsync();

            if (overlappingShift != null)
            {
                return false;

                throw new InvalidOperationException("The shift overlaps with an existing shift for this employee.");
            }
            #endregion

            var shift = await _shiftRepository.GetByIdAsync(updateShiftDto.Id);
            _mapper.Map(updateShiftDto, shift);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteShiftAsync(int id)
        {
            try
            {
                await _shiftRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(AssignShiftDto assignShiftDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(assignShiftDto.EmployeeId);
            
            #region Should be moved in a validator class
            if (employee == null)
            {
                return false;
            }

            var role = await _employeeRoleRepository.GetByIdAsync(assignShiftDto.EmployeeRoleId);
            if (role == null)
            {
                return false;
            }

            if (assignShiftDto.EndTime <= assignShiftDto.StartTime)
            {
                return false;
            }

            var overlappingShift = await _shiftRepository.AsQueryable()
                .Where(s => s.EmployeeId == assignShiftDto.EmployeeId &&
                            s.ShiftDate == assignShiftDto.ShiftDate &&
                            s.StartTime < assignShiftDto.EndTime &&
                            s.EndTime > assignShiftDto.StartTime)
                .FirstOrDefaultAsync();

            if (overlappingShift != null)
            {
                return false;
            }
            #endregion


            var shift = _mapper.Map<Shift>(assignShiftDto); 

            await _shiftRepository.AddAsync(shift);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<Shift>> GetShiftsForEmployeeAsync(int employeeId)
        {
            return await _shiftRepository
                .AsQueryable()
                .Where(shift => shift.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}
