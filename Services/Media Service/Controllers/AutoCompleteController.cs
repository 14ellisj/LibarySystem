using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Controllers
{
    [Route("[controller]")]
    public class AutoCompleteController : Controller
    {
        private readonly ILogger<AutoCompleteController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AutoCompleteController(ILogger<AutoCompleteController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("Title", Name = "GetMediaWithTitle")]
        public async Task<JsonResult> GetTitles(string name)
        {
            name = name.Trim();

            if (string.IsNullOrWhiteSpace(name))
                return Json(new List<Author>());

            var titleSpec = new MediaTitleSpecification(name, false);

            var query = _context.Media
                .ApplySpecification(titleSpec)
                .Take(5);

            try
            {
                var result = await query.ToListAsync();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet("Author", Name = "GetAuthor")]
        public async Task<JsonResult> GetAuthor(string name)
        {
            name = name.Trim();

            if (string.IsNullOrWhiteSpace(name))
                return Json(new List<Author>());

            var authorSpec = new AuthorNameSpecification(name);

            var query = _context.Author
                .ApplySpecification(authorSpec)
                .Take(5);

            try 
            {
                var result = await query.ToListAsync();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }

        }
    }
}