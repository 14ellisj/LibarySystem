﻿using AutoMapper;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;

namespace Media_Service.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaDatabase _mediaDatabase;
        private readonly IMapper _mapper;
        public MediaService(IMediaDatabase mediaDatabase, IMapper mapper)
        {
            _mediaDatabase = mediaDatabase;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable)
        {
            MediaTitleSpecification titleSpec = new MediaTitleSpecification(title, isSelected);
            MediaAuthorSpecification authorSpec = new MediaAuthorSpecification(author, isSelected);
            MediaAvailabilitySpecification availabilitySpec = new MediaAvailabilitySpecification(isAvailable);

            List<ISpecification<MediaEntity>> specs = new()
            {
                titleSpec,
                authorSpec,
                availabilitySpec
            };

            var entities = await _mediaDatabase.FilterMediaAllInfo(specs);
            var mapped = _mapper.Map<IEnumerable<Media>>(entities);

            return mapped;
        }
    }
}
