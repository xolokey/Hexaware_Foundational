using AuthenticationDemo.DTO;
using AuthenticationDemo.Models;
using AutoMapper;

namespace AuthenticationDemo.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
