using System.Diagnostics;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class GenericUnitOfWork: IUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly BookReservationSystemDbContext _context;

    public GenericUnitOfWork(BookReservationSystemDbContext context)
    {
        _context = context;
        _transaction = _context.Database.BeginTransaction();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
        await _transaction.CommitAsync();
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
        _transaction = await _context.Database.BeginTransactionAsync();
    }
    
    public void Dispose()
    {
        _transaction.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _transaction.DisposeAsync();
    }
}