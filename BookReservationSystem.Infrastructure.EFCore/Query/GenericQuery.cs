using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystem.Infrastructure.EFCore.Query;

public class GenericQuery<TEntity> : Query<TEntity> where TEntity : class, new()
{
    private BookReservationSystemDbContext Context { get; }

    public GenericQuery(BookReservationSystemDbContext context)
    {
        Context = context;
    }

    public override async Task<IEnumerable<TEntity>> Execute()
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (WherePredicates.Count != 0)
        {
            query = ApplyWhere(query);
        }

        if (OrderByProviders.Count != 0)
        {
            query = ApplyOrderBy(query);
        }

        if (Pagination.HasValue)
        {
            query = ApplyPagination(query);
        }

        return await query.ToListAsync();

    }

    private IQueryable<TEntity> ApplyWhere(IQueryable<TEntity> query)
    {
        return WherePredicates.Aggregate(
            query, 
            (current, predicate) => current.Where(predicate));
    }

    private IQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query)
    {
        return OrderByProviders.Aggregate(
            query, 
            (current, value) => 
                value.isAscending 
                    ? current.OrderBy(value.Item1) 
                    : current.OrderByDescending(value.Item1));
    }

    private IQueryable<TEntity> ApplyPagination(IQueryable<TEntity> query)
    {
        var page = Pagination!.Value.PageToFetch;
        var pageSize = Pagination!.Value.PageSize;

        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}