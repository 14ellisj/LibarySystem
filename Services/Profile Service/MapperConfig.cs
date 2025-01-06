using AutoMapper;
using Profile_Service.Models;

namespace Profile_Service
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProfileEntity, UserProfile>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<Role>(src.role.role.ToUpper())));
            CreateMap<LibraryEntity, Library>();
            CreateMap<AddressEntity, Address>();
        }
    }


}
