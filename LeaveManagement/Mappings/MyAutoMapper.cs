using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models.ViewModels;

namespace LeaveManagement.Mappings
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            //CreateMap<LeaveType, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
