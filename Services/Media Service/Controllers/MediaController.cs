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

        [HttpGet(Name = "Get Media")]
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia(string? title, string? author, bool? isSelected, bool? availability)
        {
            var results = await _mediaService.FilterMedia(title, author, isSelected, availability);
            
            return Ok(results);
        }

        [HttpPatch("borrow", Name = "Borrow Media")]
        public async Task<IActionResult> BorrowMedia([FromBody] BorrowItemRequest body)
        {
            if (!body.MediaId.HasValue || !body.ProfileId.HasValue)
                return BadRequest("Please include a media_id and a profile_id");

            try
            {
                var success = await _mediaService.BorrowMedia((int)body.MediaId, (int)body.ProfileId);

                if (success)
                    return Ok();

                return Conflict("No available items");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}