using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class ReviewUnitOfWork : GenericUnitOfWork, IReviewUnitOfWork
{
    private IRepository<Book>? _bookRepository;
    private IRepository<Review>? _reviewRepository;
    private IRepository<User>? _userRepository;

    public ReviewUnitOfWork(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
    public IRepository<Review> ReviewRepository => _reviewRepository ??= new GenericRepository<Review>(Context);
    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(Context);
}