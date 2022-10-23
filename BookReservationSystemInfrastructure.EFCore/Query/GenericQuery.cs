using System.Linq.Expressions;
using BookReservationSystemDAL.Data;
using BookReservationSystemInfrastructure.EFCore.Query.Helpers;
using BookReservationSystemInfrastructure.Query;
using BookReservationSystemInfrastructure.EFCore.UnitOfWork;

namespace BookReservationSystemInfrastructure.EFCore.Query;

public class GenericQuery<TEntity> : Query<TEntity> where TEntity : class, new()
{
    protected BookReservationSystemDbContext Context { get; set; }

    public GenericQuery(BookReservationSystemDbContext context)
    {
        Context = context;
    }

    public override IEnumerable<TEntity> Execute()
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (WherePredicate.Capacity != 0)
        {
            query = ApplyWhere(query);
        }

        if (OrderByContainer != null)
        {
            query = OrderBy(query);
        }

        if (PaginationContainer.HasValue)
        {
            query = Pagination(query);
        }

        return query.ToList();

    }

    private IQueryable<TEntity> ApplyWhere(IQueryable<TEntity> query)
    {
        foreach (var expr in WherePredicate)
        {
            var p = Expression.Parameter(typeof(TEntity), "p");
            
            var columnNameFromObject = typeof(TEntity)
                .GetProperty(expr.columnName)
                ?.Name;

            var exprProp = Expression.Property(p, columnNameFromObject);
            
            var expression = expr.expression;

            var parameters = (IReadOnlyCollection<ParameterExpression>)expression
                .GetType()
                .GetProperty("Parameters")
                ?.GetValue(expression);

            var body = (Expression)expression
                .GetType()
                .GetProperty("Body")
                ?.GetValue(expression);

            var visitor = new ReplaceParamVisitor(parameters.First(), exprProp);
            var exprNewBody = visitor.Visit(body);
            
            var lambda = Expression.Lambda<Func<TEntity, bool>>(exprNewBody, p);

            query = query.Where(lambda);
        }

        return query;
    }

    private IQueryable<TEntity> OrderBy(IQueryable<TEntity> query)
    {
        var orderByColumn = OrderByContainer.Value.tableName;
        var isAscending = OrderByContainer.Value.isAscending;
        var argumentType = OrderByContainer.Value.argumentType;

        var p = Expression.Parameter(typeof(TEntity), "p");

        var columnNameFromObject = typeof(TEntity)
            .GetProperty(orderByColumn)
            ?.Name;

        var exprProp = Expression.Property(p, columnNameFromObject);
        var lambda = Expression.Lambda(exprProp, p);

        var orderByMethod = typeof(Queryable)
            .GetMethods()
            .First(a => a.Name == (isAscending ? "OrderBy" : "OrderByDescending") && a.GetParameters().Length == 2);

        var orderByClosedMethod = orderByMethod.MakeGenericMethod(typeof(TEntity), argumentType);

        return (IQueryable<TEntity>)orderByClosedMethod.Invoke(null, new object[] { query, lambda })!;
    }

    private IQueryable<TEntity> Pagination(IQueryable<TEntity> query)
    {
        var page = PaginationContainer.Value.PageToFetch;
        var pageSize = PaginationContainer.Value.PageSize;

        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}