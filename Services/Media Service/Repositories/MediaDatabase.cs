using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Repositories
{
    public class MediaDatabase : IMediaDatabase
    {
        private readonly AppDbContext _context;
        public MediaDatabase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BorrowItem(MediaItemEntity mediaItem, int profileId)
        {
            mediaItem.borrower_id = profileId;

            _context.Update(mediaItem);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            } 
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ReserveItem(MediaItemEntity mediaItem, int profileId)
        {
            mediaItem.reserver_id = profileId;

            _context.Update(mediaItem);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            } 
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<MediaEntity>> FilterMediaAllInfo(IEnumerable<ISpecification<MediaEntity>> specs)
        {
            var query = _context.Media
                .Include(x => x.author)
                .Include(x => x.genre)
                .Include(x => x.type)
                .Include(x => x.media_items)
                    .ThenInclude(mi => mi.borrower)
                .ApplySpecifications(specs)
                .OrderBy(x => x.name);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<MediaItemEntity>> GetMediaItemsById(MediaItemIdSpecification spec)
        {
            var query = _context.MediaItem
                .Include(x => x.library)
                .Include(x => x.borrower)
                .Include(x => x.reserver)
                .Include(x => x.media)
                .ApplySpecification(spec);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<LibraryEntity>> GetLibraryDataById(LibrarySpecification spec)
        {
            var query = _context.Library
                .ApplySpecification(spec);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AuthorEntity>> GetAuthorsByName(AuthorNameSpecification spec)
        {
            var dbQuery = _context.Author
                    .ApplySpecification(spec)
                    .OrderBy(x => x.last_name)
                    .Take(5);

            return await dbQuery.ToListAsync();
        }

        public async Task<IEnumerable<MediaEntity>> GetMediaByTitle(MediaTitleSpecification spec)
        {
            var query = _context.Media
                    .ApplySpecification(spec)
                    .Distinct()
                    .OrderBy(x => x.name)
                    .Take(5);

            return await query.ToListAsync();
        }
    }
}
