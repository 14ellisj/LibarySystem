using System.Linq.Expressions;

namespace Media_Service.Models.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
