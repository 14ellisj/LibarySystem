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
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia(string? title, string? author, bool? isSelected, bool? availability)
        {
            var results = await _mediaService.FilterMedia(title, author, isSelected, availability);
            
            return Ok(results);
        }

        [HttpGet(Name = "Get Borrowed Media")]
        public async Task<ActionResult<IEnumerable<Media>>> GetBorrowedMedia(int profileID)
        {
            if (profileID == null)
                return BadRequest("No Profile Id");
                
            var results = await _mediaService.GetBorrowedMedia(profileID);
            
            return Ok(results);
        }

        [HttpPatch("borrow", Name = "Borrow Media")]
        public async Task<IActionResult> BorrowMedia([FromBody] BorrowItemRequest body)
        {
            if (!body.MediaId.HasValue || !body.ProfileId.HasValue)
                return BadRequest("Please include a media_id and a profile_id");

            var success = await _mediaService.BorrowMedia((int)body.MediaId, (int)body.ProfileId);

            if (success)
                return Ok();

            return Conflict("No available items");

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