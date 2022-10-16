using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemInfrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Data;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public class GenericUnitOfWork<TRepo, TEntity> : IDisposable 
        where TRepo : GenericRepository<TEntity>
        where TEntity : class
    {
        private BookReservationSystemDBContext _context = null;
        private Dictionary<Type, TRepo> repositories = new Dictionary<Type, TRepo>();

        public GenericUnitOfWork()
        {
            _context = new BookReservationSystemDBContext();
        }

        public GenericUnitOfWork(BookReservationSystemDBContext _context)
        {
            this._context = _context;
        }

        public TRepo Repository()
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)];
            }
            //not sure about this
            TRepo repo = (TRepo)Activator.CreateInstance(typeof(TRepo), new object[] {});
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public IEnumerable<TRepo> GetAll()
        {
            return repositories.Values.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
