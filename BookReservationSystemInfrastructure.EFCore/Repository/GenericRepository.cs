﻿using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Data;
using BookReservationSystemInfrastructure.Repository;

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

    public TEntity? GetById(object id)
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

    public void Delete(object id)
    {
        var existing = _table.Find(id);
        if (existing != null)
        {
            _table.Remove(existing);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}