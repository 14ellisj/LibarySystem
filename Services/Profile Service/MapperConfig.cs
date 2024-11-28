using AutoMapper;
using Profile_Service.Models;

namespace Profile_Service
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity, UserProfile>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DOB));
            CreateMap<RoleEntity, Role>();
            CreateMap<LibraryEntity, Library>();
            CreateMap<AddressEntity, Address>();
        }
    }


}
