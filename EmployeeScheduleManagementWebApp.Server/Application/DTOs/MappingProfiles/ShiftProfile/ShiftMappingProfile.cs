using AutoMapper;
using EmployeeScheduleManagementWebApp.Server.Application.Interfaces;
using EmployeeScheduleManagementWebApp.Server.Application.Services;
using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Application.DTOs.MappingProfiles.ShiftProfile
{
    public class ShiftMappingProfile : Profile
    {
        public ShiftMappingProfile()
        {
            CreateMap<Shift, GetEmployeeShiftDto>();
            CreateMap<UpdateShiftDto, Shift>();
            CreateMap<AssignShiftDto, Shift>();
        }
    }
}
