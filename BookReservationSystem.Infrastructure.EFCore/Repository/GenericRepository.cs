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

    public IEnumerable<TEntity> FindAll()
    {
        return _table.ToList();
    }

    public TEntity? FindById(Guid id)
    {
        return _table.Find(id);
    }

    public void Insert(TEntity obj)
    {
        _table.Add(obj);
    }

    public void Update(TEntity obj)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
        var existing = _table.Find(id);
        if (existing == null)
        {
            throw new ArgumentException("Could not find Item with Id: " + id);
        }
        _table.Remove(existing);
    }

    public void Delete(TEntity obj)
    {
        if (_context.Entry(obj).State == EntityState.Detached)
        {
            _table.Attach(obj);
        }
        _table.Remove(obj);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
