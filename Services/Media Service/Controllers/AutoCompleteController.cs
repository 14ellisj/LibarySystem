using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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

        [HttpGet(Name = "Get Auto Complete Options")]
        public async Task<ActionResult<IEnumerable<string>>> GetAutoComplete(string query, SearchType search_type)
        {
            query = query.Trim();

            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Please include a query.");

            if (search_type == SearchType.TITLE)
            {
                if (string.IsNullOrWhiteSpace(query))
                    return Ok(new List<string>());

                var titleSpec = new MediaTitleSpecification(query, false);

                var dbQuery = _context.Media
                    .ApplySpecification(titleSpec)
                    .Distinct()
                    .OrderBy(x => x)
                    .Take(5);

                try
                {
                    var result = await dbQuery.ToListAsync();
                    return Ok(result.Select(x => x.name));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                var authorSpec = new AuthorNameSpecification(query);

                var dbQuery = _context.Author
                    .ApplySpecification(authorSpec)
                    .Take(5);

                try
                {
                    var result = await dbQuery.ToListAsync();
                    return Ok(result.Select(x => x.first_name + " " + x.last_name));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}