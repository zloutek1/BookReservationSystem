using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemDAL.Models;
using System.Collections.Generic;

namespace BookReservationSystemDAL.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void Save();
    }
}
