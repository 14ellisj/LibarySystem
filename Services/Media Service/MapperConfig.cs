﻿using AutoMapper;
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
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.media_items.Any(mi => mi.borrower == null)));

            CreateMap<AuthorEntity, Author>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.first_name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.last_name));

            CreateMap<MediaItemEntity, MediaItem>();
                //.ForMember(dest => dest.Library, opt => opt.MapFrom(src => src.library))
               // .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.media))
               // .ForMember(dest => dest.Borrower, opt => opt.MapFrom(src => src.borrower))
               // .ForMember(dest => dest.Reserver, opt => opt.MapFrom(src => src.reserver));
             CreateMap<UserEntity, User>();
             CreateMap<LibraryEntity, Library>();
        }
    }
}
