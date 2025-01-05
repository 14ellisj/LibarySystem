using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace API_Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouterController : Controller
    {

        private readonly ILogger<RouterController> _logger;

        public RouterController(ILogger<RouterController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRouter")]
        public JsonResult Get()
        {
            Media returning = new Media()
            {
                author = new Author() { first_name = "First Name", last_name = "Last Name" },
                type = new Type() { name = "name"},
                genre = Genre,
                name = "Media Name"
            };

            return Json(new List<Media>() { returning });
        }
    }
}

