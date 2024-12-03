using Wishlist_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Wishlist_Service.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WishlistEntity> Wishlist { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }
    }
}
