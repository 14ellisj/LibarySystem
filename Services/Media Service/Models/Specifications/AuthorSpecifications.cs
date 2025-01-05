using System.Linq.Expressions;

namespace Media_Service.Models.Specifications
{
    public class AuthorNameSpecification : ISpecification<AuthorEntity>
    {
        string? _query;
        public AuthorNameSpecification(string? query)
        {
            _query = query;
        }
        public Expression<Func<AuthorEntity, bool>> Criteria
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_query))
                    return _ => true;

                var authorNames = _query.Trim().ToLower().Split(" ");
                return x => authorNames.All(name =>
                          x.first_name.ToLower().Contains(name) ||
                          x.last_name.ToLower().Contains(name));
            }
        }
    }
}
