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
        private readonly ILogger<MediaService> _logger;

        public MediaService(IMediaDatabase mediaDatabase, IMapper mapper, ILogger<MediaService> logger)
        {
            _mediaDatabase = mediaDatabase;
            _logger = logger;
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
        public async Task<bool> MoveMedia(int mediaItemId, int newLibraryId)
        {
            return await _mediaDatabase.MoveItem(mediaItemId, newLibraryId);
        }

        public async Task<bool> ReserveMedia(int mediaId, int profileId)
        {
            var mediaItems = await _mediaDatabase.GetMediaItemsByParentId(mediaId);

            if (mediaItems.Count() == 0)
                return false;

            var isUserCurrentlyReserving = mediaItems.Any(x => x.Reserver?.Id == profileId);
            if (isUserCurrentlyReserving)
                return false;

            var availableItems = mediaItems.Where(x => x.Reserver is null);
            if (availableItems.Count() == 0)
                return false;

            return await _mediaDatabase.ReserveItem(availableItems.First().Id, profileId);
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

            return await _mediaDatabase.ReturnItem(returningItem.Id);
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
            var media = await GetMediaById(id);

            if (media is null)
                throw new Exception("Media Not Found.");

            return media;
        }
        public async Task<IEnumerable<MediaItem>> GetMediaItems(int mediaId, int? libraryId, int? borrowerId, int? reserverId)
        {
            var items = await _mediaDatabase.GetMediaItemsByParentId(mediaId);

            if (items.Count() == 0)
                throw new Exception("Media items Not Found.");
            
            return items;
        }
        public async Task<IEnumerable<MediaItem>> GetLibraryMediaItems(int libraryId, int? mediaId)
        {
            var items = await _mediaDatabase.GetMediaItemsByLibraryId(libraryId);

            if (items.Count() == 0)
                throw new Exception("Library media items Not Found.");
            
            return items;
        }

         public async Task<IEnumerable<Library>> GetLibraryData(int? libraryId, string? libraryName)
        {
            var items = await _mediaDatabase.GetAllLibraryData();

            if (items.Count() == 0)
                throw new Exception("Media items Not Found.");
            
            return items;
        }

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profile_id)
        {
            var media = await _mediaDatabase.GetBorrowedMedia(profile_id);
            return media;
        }

        private async Task<Media?> GetMediaById(int id)
        {
            MediaFilter filter = new() { Id = id };
            return (await _mediaDatabase.FilterMediaAllInfo(filter)).FirstOrDefault();
        }
    }
}
