using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;
using AutoMapper;

namespace AssertManagementAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Assert,AssertDTO>().ReverseMap();
        }
    }
}
