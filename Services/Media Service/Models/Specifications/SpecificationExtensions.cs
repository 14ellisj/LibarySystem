namespace Media_Service.Models.Specifications
{
    public static class SpecificationExtensions
    {
        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> spec)
        {
            return query.Where(spec.Criteria);
        }
    }
}
