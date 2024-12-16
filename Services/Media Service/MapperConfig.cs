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
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<MediaType>(src.type.name.ToUpper())))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.media_items.Any(mi => mi.borrower == null)))
                .ForMember(dest => dest.IsBorrwedByUser, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                   Dictionary<string, object> contextItems;
                   var hasContext = context.TryGetItems(out contextItems);

                    if (!hasContext)
                        return false;

                    var hasProfile = contextItems.ContainsKey("profile_id");
                    if (!hasProfile)
                        return false;

                    var profileId = (int?)contextItems["profile_id"];
                    if (!profileId.HasValue) 
                        return false;

                    return src.media_items.Any(mi => mi.borrower_id == profileId);
                }));

            CreateMap<AuthorEntity, Author>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name));

            CreateMap<MediaItemEntity, MediaItem>()
                .ForMember(dest => dest.Library, opt => opt.MapFrom(src => src.library))
                .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.media))
                .ForMember(dest => dest.Borrower, opt => opt.MapFrom(src => src.borrower_id));
        }
    }
}
