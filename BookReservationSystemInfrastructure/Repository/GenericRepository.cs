using BookReservationSystemDAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Repository
{
    public class GenericRepository<TEntity> : IDisposable, 
        IGenericRepository<TEntity> where TEntity : class
    {
        private BookReservationSystemDBContext _context = null;
        private DbSet<TEntity> table = null;
        public GenericRepository()
        {
            this._context = new BookReservationSystemDBContext();
            table = _context.Set<TEntity>();
        }
        public GenericRepository(BookReservationSystemDBContext _context)
        {
            this._context = _context;
            table = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return table.ToList();
        }
        public TEntity GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(TEntity obj)
        {
            table.Add(obj);
        }
        public void Update(TEntity obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            TEntity existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
