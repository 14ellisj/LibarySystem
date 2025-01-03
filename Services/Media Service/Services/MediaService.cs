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
        private readonly Database.AppDbContext _context;
        private readonly ILogger<MediaService> _logger;

        public MediaService(IMediaDatabase mediaDatabase, IMapper mapper, Database.AppDbContext context, ILogger<MediaService> logger)
        {
            _mediaDatabase = mediaDatabase;
            _mapper = mapper;
            _context = context;
            _logger = logger;
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

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profileID)
        {
            MediaItemBorrowerSpecification borrower = new MediaItemBorrowerSpecification(profileID);
            List<MediaEntity> mediaList = new List<MediaEntity>();
            var mediaItems = await _mediaDatabase.GetBorrowedMedia(borrower);

            if (mediaItems.Count() == 0)
            {
                var mapped = _mapper.Map<IEnumerable<Media>>(mediaList);
                return mapped;
            }

            else
            {
                foreach (var item in mediaItems)
                {
                    mediaList.Add(item.media);
                }
                var mapped = _mapper.Map<IEnumerable<Media>>(mediaList);

                return mapped;
            }
        }
    }
}
