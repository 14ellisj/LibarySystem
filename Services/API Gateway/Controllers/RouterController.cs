﻿using Microsoft.AspNetCore.Mvc;
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
                type = Type.AUDIO_BOOK,
                genre = Genre.CRIME,
                name = "Media Name"
            };

            return Json(returning);
        }
    }
}
