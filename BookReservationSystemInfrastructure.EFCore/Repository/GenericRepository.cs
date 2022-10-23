using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Data;
using BookReservationSystemInfrastructure.Repository;
using System.Collections.Generic;

namespace BookReservationSystemInfrastructure.EFCore.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly BookReservationSystemDbContext _context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository()
    {
        _context = new BookReservationSystemDbContext();
        _table = _context.Set<TEntity>();
    }

    public GenericRepository(BookReservationSystemDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public GenericRepository(DbSet<TEntity> table)
    {
        _context = new BookReservationSystemDbContext();
        _table = table;
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

    public void Delete(TEntity obj)
    {
        if (_context.Entry(obj).State == EntityState.Detached)
        {
            _table.Attach(obj);
        }
        _table.Remove(obj);
    }
}
