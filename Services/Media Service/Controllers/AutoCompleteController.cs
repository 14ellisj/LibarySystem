using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Media_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Media_Service.Controllers
{
    [Route("[controller]")]
    public class AutoCompleteController : Controller
    {
        private readonly ILogger<AutoCompleteController> _logger;
        private readonly IAutoCompleteService _autoCompleteService;
        public AutoCompleteController(ILogger<AutoCompleteController> logger, IAutoCompleteService autoCompleteService)
        {
            _logger = logger;
            _autoCompleteService = autoCompleteService;
        }

        [HttpGet(Name = "Get Auto Complete Options")]
        public async Task<ActionResult<IEnumerable<string>>> GetAutoComplete(string query, SearchType search_type)
        {
            query = query.Trim();

            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Please include a query.");


            var result = await _autoCompleteService.GetAutoComplete(query, search_type);

            return Ok(result);
        }
    }
}