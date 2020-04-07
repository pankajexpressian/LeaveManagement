using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models.ViewModels;

namespace LeaveManagement.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<LeaveType, DetailsLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
