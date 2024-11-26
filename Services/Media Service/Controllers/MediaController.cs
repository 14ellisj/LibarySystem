using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {

        private readonly ILogger<MediaController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public MediaController(ILogger<MediaController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMedia")]
        [HttpGet(Name = "GetAuthor")]
        public async Task<JsonResult> Get(string? title, string? author, bool? availability)
        {

            var query = _context.Media
                .Include(x => x.author)
                .Include(x => x.genre)
                .Include(x => x.type)
                .Include(x => x.rating)
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


            return Json(output);
        }
    }
}