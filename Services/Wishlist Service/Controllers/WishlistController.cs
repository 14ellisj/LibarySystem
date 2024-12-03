using AutoMapper;
using Wishlist_Service.Database;
using Wishlist_Service.Models;
using Wishlist_Service.Models.Specifications;
using Wishlist_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Wishlist_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishlistController : Controller
    {

        private readonly ILogger<WishlistController> _logger;
        private readonly IWishlistService _wishlistService;

        public WishlistController(ILogger<WishlistController> logger, IWIshlistService wishlistService)
        {
            _logger = logger;
            _wishlistService = wishlistService;
        }

        [HttpGet(Name = "Get Wishlist")]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist(string? title, string? author, bool? isSelected, bool? availability)
        {
            var results = await _wishlistService.FilterWishlist(title, author, isSelected, availability);
            
            return Ok(results);
        }
    }
}