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
        private readonly Database.AppDbContext _context;
        public MediaService(IMediaDatabase mediaDatabase, IMapper mapper, Database.AppDbContext context)
        {
            _mediaDatabase = mediaDatabase;
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> BorrowMedia(int mediaId, int profileId)
        {
            MediaIdSpecification idSpec = new MediaIdSpecification(mediaId);

            var media = (await _mediaDatabase.FilterMediaAllInfo([idSpec])).First();

            var isUserCurrentlyBorrowing = media.media_items.Any(x => x.borrower_id ==  profileId);
            if (isUserCurrentlyBorrowing)
                return false;

            var availableItems = media.media_items.Where(x => x.borrower is null);
            if (availableItems.Count() == 0)
                return false;

            return await _mediaDatabase.BorrowItem(availableItems.First(), profileId);
        }

        public async Task<bool> ReturnMedia(int mediaId, int profileId)
        {
            MediaIdSpecification idSpec = new MediaIdSpecification(mediaId);
            var media = (await _mediaDatabase.FilterMediaAllInfo([idSpec])).First();

            var returnItem = media.media_items.Where(x => x.borrower_id == profileId);

            if (returnItem.Count() == 0)
                return false;

            return await _mediaDatabase.ReturnItem(returnItem.First());
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

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profileID)
        {
            var media = await _mediaDatabase.GetAllMedia();

            var borrowedMedia = media.media_items.Where(x => x.borrower_id ==  profileID);

            var mapped = _mapper.Map<IEnumerable<Media>>(borrowedMedia);

            return mapped;
        }
    }
}
