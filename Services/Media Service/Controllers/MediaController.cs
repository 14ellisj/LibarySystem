using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
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
        public async Task<JsonResult> Get(string? title, string? author, bool? isSelected, bool? availability)
        {

            var query = _context.Media
                .Include(x => x.author)
                .Include(x => x.genre)
                .Include(x => x.type)
                .Include(x => x.media_items)
                    .ThenInclude(mi => mi.borrower)
                .AsQueryable();


            MediaTitleSpecification titleSpec = new MediaTitleSpecification(title, isSelected);
            MediaAuthorSpecification authorSpec = new MediaAuthorSpecification(author, isSelected);
            MediaAvailabilitySpecification availabilitySpec = new MediaAvailabilitySpecification(availability);

            query = query
                .ApplySpecification(titleSpec)
                .ApplySpecification(authorSpec)
                .ApplySpecification(availabilitySpec);

            try
            {
                var results = await query.ToListAsync();
                var output = _mapper.Map<IEnumerable<MediaEntity>, IEnumerable<Media>>(results);


                return Json(output);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
    }
}