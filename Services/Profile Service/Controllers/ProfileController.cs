using AutoMapper;
using Profile_Service.Database;
using Profile_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Profile_Service.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProfileController(ILogger<ProfileController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProfile")]
        public async Task<JsonResult> Get(string? firstName, string? lastName)
        {
            var query = _context.Profile
                .Include(x => x.address)
                .Include(x => x.role)
                .Include(x => x.library)
                .AsQueryable();

                query = query.Where(x => x.first_name.ToLower().Contains(firstName.ToLower()));

            var results = await query.ToListAsync();
            var output = _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserProfile>>(results);


            return Json(output);
        }
    }
}

            /*var query = _context.Media
                .Include(x => x.author)
                .Include(x => x.genre)
                .Include(x => x.type)
                .AsQueryable();

            if (title is not null)
                query = query.Where(x => x.name.ToLower().Contains(title.ToLower()));

            if (author is not null)
            {
                var authorSplit = author.Split(" ");
                var first = authorSplit.First().ToLower();
                var last = authorSplit.Last().ToLower();

                if (authorSplit.Length == 1)
                {
                    query = query.Where(x => x.author.first_name.ToLower().Contains(first) || x.author.last_name.ToLower().Contains(last));
                }
                else
                {
                    query = query.Where(x =>
                        x.author.first_name.ToLower().Contains(first)
                        || x.author.first_name.ToLower().Contains(last)
                        || x.author.last_name.ToLower().Contains(first)
                        || x.author.last_name.ToLower().Contains(last)
                    );
                }

            }



            if (availability.HasValue)
            {
                // Get IDs of Media entries that have available or all borrowed copies based on availability
                var mediaIdsWithAvailability = availability.Value
                    ? _context.MediaItem
                        .Where(item => item.borrower == null) // Only available copies
                        .Select(item => item.media.id)
                        .Distinct()
                        .ToList()
                    : _context.MediaItem
                        .GroupBy(item => item.media.id) // Group by Media ID first
                        .Where(g => g.All(item => item.borrower != null)) // Check all copies are borrowed
                        .Select(g => g.Key)
                        .ToList();

                if (!mediaIdsWithAvailability.Any())
                    return Json(new List<Media>());

                // Filter Media query based on these IDs
                query = query.Where(x => mediaIdsWithAvailability.Contains(x.id));
            }

            var results = await query.ToListAsync();
            var output = _mapper.Map<IEnumerable<MediaEntity>, IEnumerable<Media>>(results);


            return Json(output);*/