using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IPublisherUOW : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Publisher> PublisherRepository { get; }
        public Task Commit();
    }
}
