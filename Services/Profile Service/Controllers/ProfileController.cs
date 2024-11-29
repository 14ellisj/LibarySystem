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
        public async Task<JsonResult> Get(string? email)
        {
            var query = _context.Profile
                .Include(x => x.address)
                .Include(x => x.role)
                .Include(x => x.library)
                .AsQueryable();

                query = query.Where(x => x.email.ToLower().Contains(email.ToLower()));

            var results = await query.ToListAsync();
            var output = _mapper.Map<IEnumerable<ProfileEntity>, IEnumerable<UserProfile>>(results);


            return Json(output);
        }
    }
}