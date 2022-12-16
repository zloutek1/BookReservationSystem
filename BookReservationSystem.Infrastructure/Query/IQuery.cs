using System.Linq.Expressions;

namespace BookReservationSystem.Infrastructure.Query;

public interface IQuery<TEntity> where TEntity : class, new()
{
    /// <summary>
    /// Adds a possibility to filter the result
    /// </summary>
    IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Adds a specified sort criteria to the query.
    /// </summary>
    IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> selector, bool ascendingOrder = true);

    /// <summary>
    /// Adds a possibility to paginate the result
    /// </summary>
    IQuery<TEntity> Page(int pageToFetch, int pageSize = 10);

    /// <summary>
    /// Executes the query and returns the results.
    /// </summary>
    Task<IEnumerable<TEntity>> Execute();
}