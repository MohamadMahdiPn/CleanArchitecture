using AutoMapper;
using HR_Management.Domain;
using HR_Management.UI.Models;
using HR_Management.UI.Services.Base;

namespace HR_Management.UI;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
    }
    
}