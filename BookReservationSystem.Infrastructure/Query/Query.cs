using System.Linq.Expressions;

namespace BookReservationSystem.Infrastructure.Query;

public abstract class Query<TEntity> : IQuery<TEntity> where TEntity : class, new()
{
    protected List<Expression<Func<TEntity, bool>>> WherePredicates { get; } = new();
    
    protected List<(Expression<Func<TEntity, object>>, bool isAscending)> OrderByProviders { get; } = new();
    
    protected (int PageToFetch, int PageSize)? Pagination { get; set; }

    
    public IQuery<TEntity> Page(int pageToFetch, int pageSize = 10)
    {
        Pagination = (pageToFetch, pageSize);
        return this;
    }

    public IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> provider, bool ascendingOrder = true)
    {
        OrderByProviders.Add((provider, ascendingOrder));
        return this;
    }

    public IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        WherePredicates.Add(predicate);
        return this;
    }

    public abstract Task<IEnumerable<TEntity>> Execute();
}