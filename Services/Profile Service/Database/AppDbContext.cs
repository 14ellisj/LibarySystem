using Profile_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Profile_Service.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProfileEntity> Profile {  get; set; }
    }
}
