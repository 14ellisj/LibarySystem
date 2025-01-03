﻿using AutoMapper;
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
            MediaItemParentIdSpecification idSpec = new MediaItemParentIdSpecification(mediaId);
            MediaItemBorrowStatusSpecification borrowSpec = new MediaItemBorrowStatusSpecification(false);

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

        public async Task<bool> ReturnItem(MediaItemEntity mediaItem)
        {
            mediaItem.borrower_id = null;

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
            MediaTitleSpecification titleSpec = new MediaTitleSpecification(filters.Title, filters.IsSelected);
            MediaAuthorSpecification authorSpec = new MediaAuthorSpecification(filters.Author, filters.IsSelected);
            MediaAvailabilitySpecification availabilitySpec = new MediaAvailabilitySpecification(filters.IsAvailable);
            MediaIdSpecification idSpec = new MediaIdSpecification(filters.Id);

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


        public async Task<IEnumerable<Author>> GetAuthorsByName(string author)
        {
            AuthorNameSpecification authorSpec = new AuthorNameSpecification(author);

            var dbQuery = _context.Author
                    .ApplySpecification(authorSpec)
                    .OrderBy(x => x.last_name)
                    .Take(5);

            var entities = await dbQuery.ToListAsync();
            return _mapper.Map<IEnumerable<Author>>(entities);
        }

        public async Task<IEnumerable<Media>> GetMediaByTitle(string title)
        {
            MediaTitleSpecification titleSpec = new MediaTitleSpecification(title, false);

            var query = _context.Media
                    .ApplySpecification(titleSpec)
                    .Distinct()
                    .OrderBy(x => x.name)
                    .Take(5);

            var entities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<Media>>(entities);
        }

        public async Task<IEnumerable<MediaItemEntity>> GetBorrowedMedia(MediaItemBorrowerSpecification spec)
        {
            var query = _context.MediaItems
                .Include(x => x.library)
                .Include(x => x.borrower)
                .Include(x => x.media)
                .ApplySpecification(spec);

            return await query.ToListAsync();
        }
    }
}