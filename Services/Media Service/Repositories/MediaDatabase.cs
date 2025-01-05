using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Repositories
{
    public class MediaDatabase : IMediaDatabase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MediaDatabase(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> BorrowItem(int mediaId, int profileId)
        {
            MediaItemParentIdSpecification idSpec = new(mediaId);
            MediaItemBorrowStatusSpecification borrowSpec = new(false);

            var mediaItemBorrowing = await _context.MediaItems
                .Include(x => x.media)
                .ApplySpecifications([idSpec, borrowSpec])
                .FirstOrDefaultAsync();

            if (mediaItemBorrowing is null)
                throw new Exception("Media Item not found");

            mediaItemBorrowing.borrower_id = profileId;

            _context.Update(mediaItemBorrowing);
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

        public async Task<bool> ReturnItem(MediaItem mediaItem)
        {
            var entity = _mapper.Map<MediaItemEntity>(mediaItem);
            entity.borrower_id = null;

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
        public async Task<bool> MoveItem(MediaItemEntity mediaItem, int libraryId)
        {
            mediaItem.library_id = libraryId;

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
        public async Task<IEnumerable<Media>> FilterMediaAllInfo(MediaFilter filters)
        {
            MediaTitleSpecification titleSpec = new(filters.Title, filters.IsSelected);
            MediaAuthorSpecification authorSpec = new(filters.Author, filters.IsSelected);
            MediaAvailabilitySpecification availabilitySpec = new(filters.IsAvailable);
            MediaIdSpecification idSpec = new(filters.Id);

            List<ISpecification<MediaEntity>> specs = new()
            {
                titleSpec,
                authorSpec,
                availabilitySpec,
                idSpec
            };

            var query = _context.Media
                .Include(x => x.author)
                .Include(x => x.genre)
                .Include(x => x.type)
                .Include(x => x.media_items)
                    .ThenInclude(mi => mi.borrower)
                .ApplySpecifications(specs)
                .OrderBy(x => x.name);

            var entities = await query.ToListAsync();

            return _mapper.Map<IEnumerable<Media>>(entities, opts => opts.Items["profile_id"] = filters.ProfileId);
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
        public async Task<IEnumerable<MediaItemEntity>> GetMediaItemsByLibraryId(LibraryMediaItemIdSpecification spec)
        {
            var query = _context.MediaItem
                .Include(x => x.library)
                .Include(x => x.media)
                .ApplySpecification(spec);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<LibraryEntity>> GetAllLibraryData()
        {
            var query = _context.Library;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsByName(string author)
        {
            AuthorNameSpecification authorSpec = new(author);

            var dbQuery = _context.Author
                    .ApplySpecification(authorSpec)
                    .OrderBy(x => x.last_name)
                    .Take(5);

            var entities = await dbQuery.ToListAsync();
            return _mapper.Map<IEnumerable<Author>>(entities);
        }

        public async Task<IEnumerable<Media>> GetMediaByTitle(string title)
        {
            MediaTitleSpecification titleSpec = new(title, false);

            var query = _context.Media
                    .ApplySpecification(titleSpec)
                    .Distinct()
                    .OrderBy(x => x.name)
                    .Take(5);

            var entities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Media>>(entities);
        }

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profileId)
        {
            MediaItemBorrowedBySpecification spec = new(profileId);

            var query = _context.MediaItems
                .Include(x => x.media)
                .ApplySpecification(spec);

            var mediaEntities = (await query.ToListAsync()).Select(x => x.media);

            return _mapper.Map<IEnumerable<Media>>(mediaEntities);
        }

        public async Task<MediaItem?> GetBorrowedMediaItem(int mediaId, int profileId)
        {
            MediaItemBorrowedBySpecification profileSpec = new(profileId);
            MediaItemParentIdSpecification idSpec = new(mediaId);

            var query = _context.MediaItems
                .ApplySpecifications([idSpec, profileSpec]);

            var mediaItem = (await query.ToListAsync()).FirstOrDefault();
            return _mapper.Map<MediaItem>(mediaItem);
        }
    }
}