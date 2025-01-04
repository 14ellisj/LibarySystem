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
            {
                titleSpec,
                authorSpec,
                availabilitySpec
            };

            var entities = await _mediaDatabase.FilterMediaAllInfo(specs);
            var mapped = _mapper.Map<IEnumerable<Media>>(entities, opts => opts.Items["profile_id"] = profileId);

            return mapped;
        }

        public async Task<Media> GetMedia(int id, int? profileId)
        {
            var media = await GetMediaById(id);

            if (media is null)
                throw new Exception("Media Not Found.");

            var mapped = _mapper.Map<Media>(media, opts => opts.Items["profile_id"] = profileId);
            return mapped;
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

        private async Task<MediaEntity?> GetMediaById(int id)
        {
            MediaIdSpecification idSpec = new MediaIdSpecification(id);
            return (await _mediaDatabase.FilterMediaAllInfo([idSpec])).FirstOrDefault();
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
