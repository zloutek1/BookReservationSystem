using Microsoft.EntityFrameworkCore;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.EFCore.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly BookReservationSystemDbContext _context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository(BookReservationSystemDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task<TEntity?> FindById(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task Insert(TEntity obj)
    {
        await _table.AddAsync(obj);
    }

    public Task Update(TEntity obj)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var existing = await _table.FindAsync(id);
        if (existing == null)
        {
            throw new ArgumentException("Could not find Item with Id: " + id);
        }
        _table.Remove(existing);
    }

    public Task Delete(TEntity obj)
    {
        if (_context.Entry(obj).State == EntityState.Detached)
        {
            _table.Attach(obj);
        }
        _table.Remove(obj);
        return Task.CompletedTask;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
