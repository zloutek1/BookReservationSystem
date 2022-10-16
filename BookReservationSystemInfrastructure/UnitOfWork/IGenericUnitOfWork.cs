using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    internal interface IGenericUnitOfWork<TRepo, TEntity> : IDisposable
        where TRepo : GenericRepository<TEntity>
        where TEntity : class
    {
        TRepo Repository();
        IEnumerable<TRepo> GetAll();
        void Save();
    }
}
