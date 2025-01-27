using AutoMapper;
using EmployeeScheduleManagementWebApp.Server.Application.DTOs;
using EmployeeScheduleManagementWebApp.Server.Application.Interfaces;
using EmployeeScheduleManagementWebApp.Server.Application.Services;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduleManagementWebApp.Server.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IMapper mapper,
        IEmployeeService employeeService,
        IEmployeeRoleService employeeRoleService,
        IShiftService shiftService) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IEmployeeRoleService _employeeRoleService = employeeRoleService;
        private readonly IShiftService _shiftService = shiftService;

        /// <summary>
        /// Create a new employee.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Employee</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto dto)
        {
            var employeeRoles = await _employeeRoleService.GetEmployeeRoles(dto.RoleIds);

            var hasDiscrepancyInRolesCount = dto.RoleIds.Count != employeeRoles.Count;

            if (hasDiscrepancyInRolesCount)
            {
                return BadRequest("Roles are either non-existant or duplicated!");
            }

            var newEmployee = new Employee
            {
                Name = dto.Name,
                EmployeeRoles = employeeRoles
            };

            await _employeeService.AddEmployeeAsync(newEmployee);

            return Ok(newEmployee);
        }

        /// <summary>
        /// Get an employee by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GetEmployeeDto</returns>
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound("Employee not found!");
            }

            var entityDto = _mapper.Map<GetEmployeeDto>(employee);

            return Ok(entityDto);
        }

        
    }
}
