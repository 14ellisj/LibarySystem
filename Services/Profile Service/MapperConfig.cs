using AutoMapper;
using Profile_Service.Models;

namespace Profile_Service
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity, UserProfile>();
            CreateMap<RoleEntity, Role>();
            CreateMap<LibraryEntity, Library>();
            CreateMap<AddressEntity, Address>();
        }
    }


}
