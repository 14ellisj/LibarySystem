using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Media_Service.Models.Specifications
{

    public class TitleSpecification : ISpecification<MediaEntity>
    {
        string? _query;
        public TitleSpecification(string? query)
        {
            _query = query;
        }

        public Expression<Func<MediaEntity, bool>> Criteria =>
            string.IsNullOrWhiteSpace(_query)
            ? _ => true
            : x => x.name.ToLower().Contains(_query.ToLower());
    }

    public class AuthorSpecification : ISpecification<MediaEntity>
    {
        string? _query;
        public AuthorSpecification(string? query)
        {
            _query = query;
        }
        public Expression<Func<MediaEntity, bool>> Criteria
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_query))
                    return _ => true;

                var authorNames = _query.Trim().ToLower().Split(" ");
                return x => authorNames.All(name =>
                          x.author.first_name.ToLower().Contains(name) ||
                          x.author.last_name.ToLower().Contains(name));
            }
        }
    }

    public class AvailabilitySpecification : ISpecification<MediaEntity>
    {
        bool? _isAvailable;

        public AvailabilitySpecification(bool? isAvailable)
        {
            _isAvailable = isAvailable;
        }

        public Expression<Func<MediaEntity, bool>> Criteria
        {
            get
            {
                if (!_isAvailable.HasValue)
                    return _ => true;

                return media =>
                    _isAvailable.Value
                        ? media.media_items.Any(item => item.borrower == null)
                        : media.media_items.All(item => item.borrower != null);
            }
        }
    }
}

