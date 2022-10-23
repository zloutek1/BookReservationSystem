using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Data;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.EFCore.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly BookReservationSystemDbContext _context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository(BookReservationSystemDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _table.ToList();
    }

    public TEntity? GetById(Guid id)
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

    public void Commit()
    {
        _context.SaveChanges();
    }
}
