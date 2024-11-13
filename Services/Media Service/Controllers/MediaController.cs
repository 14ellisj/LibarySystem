using Media_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Media_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : Controller
    {

        private readonly ILogger<MediaController> _logger;

        public MediaController(ILogger<MediaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRouter")]
        public JsonResult Get()
        {
            Media returning = new Media()
            {
                author = new Author() { first_name = "First Name", last_name = "Last Name" },
                type = MediaType.AUDIO_BOOK,
                genre = Genre.CRIME,
                name = "Media Name"
            };

            return Json(new List<Media>() { returning });
        }
    }
}