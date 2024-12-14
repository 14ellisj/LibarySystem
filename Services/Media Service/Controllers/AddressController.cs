using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {

        private readonly ILogger<MediaController> _logger;
        private readonly IMediaService _mediaService;

        public MediaController(ILogger<MediaController> logger, IMediaService mediaService)
        {
            _logger = logger;
            _mediaService = mediaService;
        }

        [HttpGet(Name = "Get Address")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress(int? id, int? house_number, string? street_name, string? city, string? county, string? postcode)
        {
            var results = await _mediaService.(id, house_number, street_name, city, county, postcode);
            
            return Ok(results);
        }
    }
}