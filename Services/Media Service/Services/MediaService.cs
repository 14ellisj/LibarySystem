using AutoMapper;
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

        public async Task<bool> BorrowMedia(int mediaId, int profileId)
        {
            var media = await GetMediaById(mediaId, profileId);

            if (media is null)
                return false;

            if (media.IsBorrwedByUser)
                return false;

            if (!media.IsAvailable)
                return false;

            return await _mediaDatabase.BorrowItem(mediaId, profileId);
        }

        public async Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable, int? profileId)
        {
            MediaFilter filters = new MediaFilter()
            {
                Title = title,
                Author = author,
                IsAvailable = isAvailable,
                ProfileId = profileId,
                IsSelected = isSelected
            };

            var media = await _mediaDatabase.FilterMediaAllInfo(filters);

            return media;
        }

        public async Task<Media> GetMedia(int id, int? profileId)
        {
            var media = await GetMediaById(id, profileId);

            if (media is null)
                throw new Exception("Media Not Found.");

            return media;
        }

        private async Task<Media?> GetMediaById(int id, int? profileId)
        {
            MediaFilter filters = new MediaFilter()
            {
                Id = id,
                ProfileId = profileId
            };

            return (await _mediaDatabase.FilterMediaAllInfo(filters)).FirstOrDefault();
        }
    }
}
