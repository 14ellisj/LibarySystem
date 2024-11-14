using AutoMapper;
using Media_Service.Models;

namespace Media_Service
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MediaEntity, Media>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => Enum.Parse<Genre>(src.genre.name.ToUpper())))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<MediaType>(src.type.name.ToUpper())));


            CreateMap<AuthorEntity, Author>();
            CreateMap<MediaItemEntity, MediaItem>();
        }
    }


}
