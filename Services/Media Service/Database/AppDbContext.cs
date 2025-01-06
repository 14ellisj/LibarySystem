using Media_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<MediaEntity> Media { get; set; }
        public DbSet<MediaItemEntity> MediaItems { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<LibraryEntity> Libraries { get; set; }
    }
}
