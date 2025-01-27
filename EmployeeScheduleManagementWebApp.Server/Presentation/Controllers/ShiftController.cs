using AutoMapper;
using EmployeeScheduleManagementWebApp.Server.Application.Interfaces;
using EmployeeScheduleManagementWebApp.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduleManagementWebApp.Server.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftsController(IEmployeeService employeeService,
                           IShiftService shiftService,
                           IMapper mapper) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IShiftService _shiftService = shiftService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Delete a shift.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shift = await _shiftService.GetShiftByIdAsync(id);

            if (shift == null)
            {
                return NotFound("Shift not found!");
            }

            var isSuccessful = await _shiftService.DeleteShiftAsync(id);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Update an employee's shift.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateShiftDto dto)
        {
            var shift = await _shiftService.GetShiftByIdAsync(dto.Id);

            if (shift == null) return NotFound();

            var isUpdateSuccessful = await _shiftService.UpdateShiftAsync(dto);

            if (!isUpdateSuccessful) { return BadRequest(); }

            return Ok(dto);
        }

        /// <summary>
        /// Assign shifts to employee.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shiftDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AssignShiftDto shiftDto)
        {
            var employee = await _employeeService.GetEmployeeAsync(shiftDto.EmployeeId);

            if (employee == null)
            {
                return NotFound("Employee not found!");
            }

            var isAssigningShiftSuccessful = await _shiftService.CreateAsync(shiftDto);

            if (!isAssigningShiftSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Gets the employees weekly shifts.
        /// </summary>
        /// <param name="daysOfTheWeek"></param>
        /// <returns></returns>
        [HttpPost("GetWeeklyShifts")]
        public async Task<IActionResult> GetWeeklyShifts([FromBody]List<DateTime> daysOfTheWeek)
        {
            var shifts = await _shiftService.GetAllShiftsForTheWeekAsync(daysOfTheWeek);
            return Ok(shifts);
        }
    }
}
