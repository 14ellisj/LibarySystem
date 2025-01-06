using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Media_Service.Models.Specifications
{

    public class MediaTitleSpecification : ISpecification<MediaEntity>
    {
        string? _query;
        bool? _isSelected;
        public MediaTitleSpecification(string? query, bool? isSelected)
        {
            _query = query;
            _isSelected = isSelected;
        }

        public Expression<Func<MediaEntity, bool>> Criteria
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_query))
                    return _ => true;

                if (_isSelected.HasValue && _isSelected.Value)
                {
                    return x => x.name.ToLower().Equals(_query.ToLower());
                }
                else
                {
                    return x => x.name.ToLower().Contains(_query.ToLower());
                }


            }
        }
    }

    public class MediaIdSpecification : ISpecification<MediaEntity>
    {
        int? _id;

        public MediaIdSpecification(int? id)
        {
            _id = id;
        }

        public Expression<Func<MediaEntity, bool>> Criteria
        {
            get
            {
                if (!_id.HasValue)
                    return x => true;

                return x => x.id.Equals(_id.Value);
            }
        }
    }

    public class MediaAuthorSpecification : ISpecification<MediaEntity>
    {
        string? _query;
        bool? _isAuthorSelected;
        public MediaAuthorSpecification(string? query, bool? isAuthorSelected)
        {
            _query = query;
            _isAuthorSelected = isAuthorSelected;
        }
        public Expression<Func<MediaEntity, bool>> Criteria
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_query))
                    return _ => true;

                var authorNames = _query.Trim().ToLower().Split(" ");

                if (_isAuthorSelected.HasValue && _isAuthorSelected.Value)
                {
                    return x => x.author.first_name.ToLower().Equals(authorNames.First()) &&
                              x.author.last_name.ToLower().Equals(authorNames.Last());
                }
                else
                {
                    return x => authorNames.All(name =>
                              x.author.first_name.ToLower().Contains(name) ||
                              x.author.last_name.ToLower().Contains(name));
                }
            }
        }
    }

    public class MediaAvailabilitySpecification : ISpecification<MediaEntity>
    {
        bool? _isAvailable;

        public MediaAvailabilitySpecification(bool? isAvailable)
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