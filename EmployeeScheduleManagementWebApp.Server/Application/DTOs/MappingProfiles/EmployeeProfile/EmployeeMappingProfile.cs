using AutoMapper;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Application.DTOs.MappingProfiles.EmployeeProfile
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
        }
    }
}
