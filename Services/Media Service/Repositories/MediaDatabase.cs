using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Models.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Media_Service.Repositories
{
    public class MediaDatabase
    {
        private readonly AppDbContext _context;
        public MediaDatabase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MediaEntity>> FilterMediaTitles(MediaTitleSpecification filter)
        {
            var query = _context.Media
                    .ApplySpecification(filter)
                    .Distinct()
                    .OrderBy(x => x)
                    .Take(5);

            return await query.ToListAsync();
        }
    }
}
