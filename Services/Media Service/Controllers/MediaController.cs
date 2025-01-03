using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

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
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia(string? title, string? author, bool? is_selected, bool? availability, int? profile_id)
        {
            var results = await _mediaService.FilterMedia(title, author, is_selected, availability, profile_id);
            
            return Ok(results);
        }

        [HttpGet("borrowedItem", Name = "Get Borrowed Media")]
        public async Task<ActionResult<IEnumerable<Media>>> GetBorrowedMedia(int? profile_id)
        {
            if (profile_id == null)
                return BadRequest("No Profile Id");
                
            var results = await _mediaService.GetBorrowedMedia((int)profile_id);
            
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

                if (!success)
                    return Conflict("No available items");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch("return", Name = "Return Media")]
        public async Task<IActionResult> ReturnMedia([FromBody] ReturnRequest body)
        {
            if (!body.MediaId.HasValue)
                return BadRequest("No Media Id");

            else if (!body.ProfileId.HasValue)
                return BadRequest("No Profile Id");
                
            var currentBorrowerId = (int)body.ProfileId;
            var mediaId = (int)body.MediaId;

            var returned = await _mediaService.ReturnMedia(mediaId, currentBorrowerId);

            if (returned)
                return Ok();

            return Conflict("Something went wrong");
        }
    }
}