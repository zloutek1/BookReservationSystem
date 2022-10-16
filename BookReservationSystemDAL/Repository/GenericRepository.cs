using BookReservationSystemDAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private BookReservationSystemDBContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new BookReservationSystemDBContext();
            table = _context.Set<T>();
        }
        public GenericRepository(BookReservationSystemDBContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
