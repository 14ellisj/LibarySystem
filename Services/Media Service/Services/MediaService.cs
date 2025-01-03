using AutoMapper;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;
using System.Diagnostics.Eventing.Reader;

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
            MediaFilter filters = new MediaFilter()
            {
                Id = mediaId,
                ProfileId = profileId
            };

            var media = (await _mediaDatabase.FilterMediaAllInfo(filters)).FirstOrDefault();

            if (media is null)
                return false;

            if (media.IsBorrwedByUser)
                return false;

            if (!media.IsAvailable)
                return false;

            return await _mediaDatabase.BorrowItem(mediaId, profileId);
        }

        public async Task<bool> ReturnMedia(int mediaId, int profileId)
        {
            MediaFilter filters = new MediaFilter()
            {
                Id = mediaId,
                ProfileId = profileId
            };

            var returningItem = await _mediaDatabase.GetBorrowedMediaItem(mediaId, profileId);

            if (returningItem is null)
                return false;

            return await _mediaDatabase.ReturnItem(returningItem);
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

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profileId)
        {
            var media = await _mediaDatabase.GetBorrowedMedia(profileId);
            return media;
        }
    }
}
