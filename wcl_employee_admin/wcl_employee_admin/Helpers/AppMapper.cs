using AutoMapper;
using wcl_employee_admin.Data;
using wcl_employee_admin.Models;
namespace wcl_employee_admin.Helpers;

public class AppMapper : Profile

{
    public AppMapper()
    {
        CreateMap<TimeOffForm, TimeOffFormModal>().ReverseMap();
        CreateMap<MissPunchForm, MissPunchFormModal>().ReverseMap();
        //CreateMap<EmpStartingInfoForm, EmployeeComplaintModal>().ReverseMap();
    }
}
