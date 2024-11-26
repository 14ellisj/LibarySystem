using Media_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GenreEntity> Genre { get; set; }
        public DbSet<MediaEntity> Media { get; set; }
        public DbSet<MediaItemEntity> MediaItem { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }
    }
}
