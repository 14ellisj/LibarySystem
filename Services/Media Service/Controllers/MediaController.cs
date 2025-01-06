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
        
        [HttpGet("item", Name = "Get Media Item")]
        public async Task<ActionResult<IEnumerable<MediaItem>>> GetMediaItems(int? media_id, int? library_id, int? borrower_id, int? reserver_id)
        {
            if (!media_id.HasValue)
                return BadRequest("Please include a media ID");

            var results = await _mediaService.GetMediaItems((int)media_id, library_id, borrower_id, reserver_id);
            return Ok(results);
        }

        [HttpGet("libraryItems", Name = "Get Library Media Items")]
        public async Task<ActionResult<IEnumerable<MediaItem>>> GetMediaItem(int? library_id, int? media_id)
        {
            if (!library_id.HasValue)
                return BadRequest("Please include a library ID");

            var results = await _mediaService.GetLibraryMediaItems((int)library_id, media_id);
            return Ok(results);
        }

        [HttpGet("library", Name = "Get Library Data")]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibraryData(int? library_id, string? library_name)
        {

            var results = await _mediaService.GetLibraryData(library_id, library_name);
            return Ok(results);
        }

        [HttpGet("borrowedItem", Name = "Get Borrowed Media")]
        public async Task<ActionResult<IEnumerable<Media>>> GetBorrowedMedia(int profileID)
        {
            if (profileID == null)
                return BadRequest("No Profile Id");
                
            var results = await _mediaService.GetBorrowedMedia(profileID);
            
            return Ok(results);
        }

        [HttpPatch("reserve", Name = "Reserve Media")]
        public async Task<IActionResult> ReserveMedia([FromBody] ReserveItemRequest body)
        {
            if (!body.MediaId.HasValue || !body.ProfileId.HasValue)
                return BadRequest("Please include a media_id and a profile_id");

            try
            {
                var success = await _mediaService.ReserveMedia((int)body.MediaId, (int)body.ProfileId);

                if (!success)
                    return Conflict("No available items");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

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

                var updatedItem = await _mediaService.GetMedia((int)body.MediaId, (int)body.ProfileId);
                return Ok(updatedItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPatch("move", Name = "Move Media")]
        public async Task<IActionResult> MoveMedia([FromBody] MoveItemRequest body)
        {
            if (!body.MediaId.HasValue || !body.LibraryId.HasValue)
                return BadRequest("Please include a media_id and a library_id");

            try
            {
                var success = await _mediaService.MoveMedia((int)body.MediaId, (int)body.LibraryId);

                if (!success)
                    return Conflict("No available items");

                var updatedItem = await _mediaService.GetMedia((int)body.MediaId, (int)body.LibraryId);
                return Ok(updatedItem);
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