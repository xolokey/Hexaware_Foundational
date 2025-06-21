using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.AssertCategory;
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
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Assert,AssertDTO>().ReverseMap();
            CreateMap<EmployeeAssert,EmployeeAssertDTO>().ReverseMap();
            CreateMap<ServiceRequest, ServiceRequestDTO>().ReverseMap();
            CreateMap<AssertCategory,AssertCategoryDTO>().ReverseMap();
        }
    }
}
