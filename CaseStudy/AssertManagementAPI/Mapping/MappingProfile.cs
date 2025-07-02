using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.AssertCategory;
using AssertManagementAPI.DTO.AuditRequest;
using AssertManagementAPI.DTO.EmployeeAssert;
using AssertManagementAPI.DTO.ServiceRequest;
using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;
using AssertManagementAPI.Model.AssetManagementAPI.Models;
using AutoMapper;

namespace AssertManagementAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee,UserDTO>().ReverseMap();
            CreateMap<Assert,AssertDTO>().ReverseMap();
            CreateMap<EmployeeAssert,EmployeeAssertDTO>().ReverseMap();
            CreateMap<ServiceRequest, ServiceRequestDTO>().ReverseMap();
            CreateMap<AssertCategory,AssertCategoryDTO>().ReverseMap();
            CreateMap<AuditRequest,AuditRequestDTO>().ReverseMap();
        }
    }
}
