using AutoMapper;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Repositories;

namespace Media_Service.Services
{
    public class ReturnService : IReturnService
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
        public async Task<bool> ReturnMedia(int mediaId, int profileId)
        {
        }
    }
}

        /*public async Task<bool> BorrowMedia(int mediaId, int profileId)
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
        }*/