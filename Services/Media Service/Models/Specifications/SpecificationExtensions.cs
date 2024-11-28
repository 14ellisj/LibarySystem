namespace Media_Service.Models.Specifications
{
    public static class SpecificationExtensions
    {
        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> spec)
        {
            return query.Where(spec.Criteria);
        }

        public static IQueryable<T> ApplySpecifications<T>(this IQueryable<T> query, IEnumerable<ISpecification<T>> specs)
        {
            foreach (ISpecification<T> spec in specs)
            {
                query.Where(spec.Criteria);
            }

            return query;
        }
    }
}
