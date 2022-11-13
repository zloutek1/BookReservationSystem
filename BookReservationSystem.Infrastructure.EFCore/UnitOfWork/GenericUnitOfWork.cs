using System.Diagnostics;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class GenericUnitOfWork: IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    protected readonly BookReservationSystemDbContext Context;

    protected GenericUnitOfWork(BookReservationSystemDbContext context)
    {
        Context = context;
        _transaction = Context.Database.BeginTransaction();
    }

    public async Task Commit()
    {
        Debug.Assert(_transaction != null, nameof(_transaction) + " != null");
        await Context.SaveChangesAsync();
        await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
        Debug.Assert(_transaction != null, nameof(_transaction) + " != null");
        await _transaction.RollbackAsync();
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
    }
}