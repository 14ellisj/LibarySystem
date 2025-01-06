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

        public async Task<bool> MoveItem(int mediaItemId, int libraryId)
        {
            var entity = await GetMediaItemEntityById(mediaItemId);

            if (entity is null)
                throw new Exception("Could not find media item by id.");

            entity.library_id = libraryId;

            _context.Update(entity);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> ReturnItem(int mediaItemId)
        {
            var entity = await GetMediaItemEntityById(mediaItemId);

            if (entity is null)
                throw new Exception("Media item by id not found.");

            entity.borrower_id = null;

            _context.Update(entity);
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

        public async Task<bool> ReserveItem(int mediaItemId, int profileId)
        {
            var mediaItemEntity = await GetMediaItemEntityById(mediaItemId);

            if (mediaItemEntity is null)
                throw new Exception("Media item id not found.");

            mediaItemEntity.reserver_id = profileId;

            _context.Update(mediaItemEntity);
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
        public async Task<IEnumerable<MediaItem>> GetMediaItemsByParentId(int mediaId)
        {
            MediaItemParentIdSpecification spec = new(mediaId);

            var query = _context.MediaItems
                .Include(x => x.library)
                .Include(x => x.borrower)
                .Include(x => x.reserver)
                .Include(x => x.media)
                .ApplySpecification(spec);

            var entities = await query.ToListAsync();

            return _mapper.Map<IEnumerable<MediaItem>>(entities);
        }

        public async Task<MediaItem> GetMediaItemById(int mediaItemId)
        {
            var entity = await GetMediaItemEntityById(mediaItemId);
            return _mapper.Map<MediaItem>(entity);
        }

        private async Task<MediaItemEntity?> GetMediaItemEntityById(int id)
        {
            MediaItemByIdSpecification spec = new(id);

            var query = _context.MediaItems
                .ApplySpecification(spec);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MediaItem>> GetMediaItemsByLibraryId(int libraryId)
        {
            MediaItemByLibraryIdSpecification spec = new(libraryId);

            var query = _context.MediaItems
                .Include(x => x.library)
                .Include(x => x.media)
                .ApplySpecification(spec);

            var entities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<MediaItem>>(entities);
        }
        public async Task<IEnumerable<Library>> GetAllLibraryData()
        {
            var query = _context.Libraries;
            var entities = await query.ToListAsync();

            return _mapper.Map<IEnumerable<Library>>(entities);
        }

        public async Task<IEnumerable<Author>> GetAuthorsByName(string author)
        {
            AuthorNameSpecification authorSpec = new(author);

            var dbQuery = _context.Authors
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

        public async Task<IEnumerable<Media>> GetBorrowedMedia(int profile_id)
        {
            MediaItemBorrowedBySpecification spec = new(profile_id);

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