using System.Diagnostics;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class GenericUnitOfWork: IUnitOfWork
{
    private IDbContextTransaction _transaction;
    protected readonly BookReservationSystemDbContext Context;

    protected GenericUnitOfWork(BookReservationSystemDbContext context)
    {
        Context = context;
        _transaction = Context.Database.BeginTransaction();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
        _transaction = await Context.Database.BeginTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
        _transaction = await Context.Database.BeginTransactionAsync();
    }
    
    public void Dispose()
    {
        _transaction.Dispose();
    }
}