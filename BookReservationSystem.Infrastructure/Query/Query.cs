﻿using System.Linq.Expressions;
using System.Security.Cryptography;

namespace BookReservationSystem.Infrastructure.Query;

public abstract class Query<TEntity> : IQuery<TEntity> where TEntity : class, new()
{
    public List<(Expression expression, Type argumentType, string columnName)> WherePredicate { get; set; } = new();
    public (string tableName, bool isAscending, Type argumentType)? OrderByContainer { get; set; }
    public (int PageToFetch, int PageSize)? PaginationContainer { get; set; }

    public IQuery<TEntity> Page(int pageToFetch, int pageSize = 10)
    {
        PaginationContainer = (pageToFetch, pageSize);
        return this;
    }

    public IQuery<TEntity> OrderBy<T>(string columnName, bool ascendingOrder = true) where T : IComparable<T>
    {
        OrderByContainer = (columnName, ascendingOrder, typeof(T));
        return this;
    }

    public IQuery<TEntity> Where<T>(Expression<Func<T, bool>> predicate, string columnName)
    {
        WherePredicate.Add((predicate, typeof(T), columnName));
        return this;
    }

    public abstract IEnumerable<TEntity> Execute();
}