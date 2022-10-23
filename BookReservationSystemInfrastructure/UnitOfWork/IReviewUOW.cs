using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IReviewUOW : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Review> ReviewRepository { get; }
        IRepository<User> UserRepository { get; }
        public Task Commit();
    }
}
