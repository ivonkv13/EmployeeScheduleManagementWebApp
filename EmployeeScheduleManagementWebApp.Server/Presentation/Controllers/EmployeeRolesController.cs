using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using EmployeeScheduleManagementWebApp.Server.Shared.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduleManagementWebApp.Server.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeRolesController(IGenericRepository<EmployeeRole> employeeRoleRepository) : ControllerBase
    {
        private readonly IGenericRepository<EmployeeRole> _employeeRoleRepository = employeeRoleRepository;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEmployeeRoles()
        {
            var allRoles = await _employeeRoleRepository.GetAllAsync();

            return Ok(allRoles);
        }
    }
}
