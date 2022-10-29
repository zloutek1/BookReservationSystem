using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class ReservationUOW : GenericUOW, IReservationUOW
{
    private IRepository<Book>? _bookRepository;
    private IRepository<Library>? _libraryRepository;
    private IRepository<Reservation>? _reservationRepository;
    private IRepository<User>? _userRepository;
    private IRepository<BookQuantity>? _bookQuantityRepository;

    public ReservationUOW(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
    public IRepository<Library> LibraryRepository => _libraryRepository ??= new GenericRepository<Library>(Context);
    public IRepository<Reservation> ReservationRepository => _reservationRepository ??= new GenericRepository<Reservation>(Context);
    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(Context);
    public IRepository<BookQuantity> BookQuantityRepository => _bookQuantityRepository ??= new GenericRepository<BookQuantity>(Context);

}