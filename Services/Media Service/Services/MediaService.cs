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
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> BorrowMedia(int mediaId, int profileId)
        {
            var media = await GetMediaById(mediaId);

            if (media is null)
                return false;

            var isUserCurrentlyBorrowing = media.media_items.Any(x => x.borrower_id ==  profileId);
            if (isUserCurrentlyBorrowing)
                return false;

            var availableItems = media.media_items.Where(x => x.borrower is null);
            if (availableItems.Count() == 0)
                return false;

            return await _mediaDatabase.BorrowItem(availableItems.First(), profileId);
        }
public async Task<bool> MoveMedia(int mediaId, int libraryId)
{
    var media = await GetMediaById(mediaId);

    if (media is null)
        return false;
   
    var availableItem = media.media_items.FirstOrDefault(); 
    
    if (availableItem == null)
        return false;

    return await _mediaDatabase.MoveItem(availableItem, libraryId);
}



        public async Task<bool> ReserveMedia(int mediaId, int profileId)
        {
            var media = await GetMediaById(mediaId);

            if (media is null)
                return false;

            var isUserCurrentlyReserving = media.media_items.Any(x => x.reserver_id ==  profileId);
            if (isUserCurrentlyReserving)
                return false;

            var availableItems = media.media_items.Where(x => x.reserver is null);
            if (availableItems.Count() == 0)
                return false;

            return await _mediaDatabase.ReserveItem(availableItems.First(), profileId);
        }

        public async Task<IEnumerable<Media>> FilterMedia(string? title, string? author, bool? isSelected, bool? isAvailable, int? profileId)
        {
            MediaTitleSpecification titleSpec = new MediaTitleSpecification(title, isSelected);
            MediaAuthorSpecification authorSpec = new MediaAuthorSpecification(author, isSelected);
            MediaAvailabilitySpecification availabilitySpec = new MediaAvailabilitySpecification(isAvailable);

            List<ISpecification<MediaEntity>> specs = new()
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
        public async Task<IEnumerable<MediaItem>> GetMediaItems(int mediaId, int? libraryId, int? borrowerId, int? reserverId)
        {
            MediaItemIdSpecification idSpec = new MediaItemIdSpecification(mediaId);
            var items = await _mediaDatabase.GetMediaItemsById(idSpec);

            _logger.LogInformation("Made it here woo!");

            if (items.Count() == 0)
                throw new Exception("Media items Not Found.");

            var mapped = _mapper.Map<IEnumerable<MediaItem>>(items);
            
            return mapped;
        }
        public async Task<IEnumerable<MediaItem>> GetLibraryMediaItems(int libraryId, int? mediaId)
        {
            LibraryMediaItemIdSpecification idSpec = new LibraryMediaItemIdSpecification(libraryId);
            var items = await _mediaDatabase.GetMediaItemsByLibraryId(idSpec);

            _logger.LogInformation("Made it here woo! (Library Media Items)");

            if (items.Count() == 0)
                throw new Exception("Library media items Not Found.");

            var mapped = _mapper.Map<IEnumerable<MediaItem>>(items);
            
            return mapped;
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

         public async Task<IEnumerable<Library>> GetLibraryData(int? libraryId, string? libraryName)
        {
            var items = await _mediaDatabase.GetAllLibraryData();

            _logger.LogInformation("Made it here woo!");

            if (items.Count() == 0)
                throw new Exception("Media items Not Found.");

            var mapped = _mapper.Map<IEnumerable<Library>>(items);
            
            return mapped;
        }
    }
}
