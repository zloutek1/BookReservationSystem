using BookReservationSystemInfrastructure.Repository;
using BookReservationSystemDAL.Data;
using BookReservationSystemDAL.Models;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork 
{
    private readonly BookReservationSystemDBContext _context;
    public UnitOfWork()
    {
        _context = new BookReservationSystemDBContext();
    }

    public UnitOfWork(BookReservationSystemDBContext context)
    {
        _context = context;
    }

    #region repositories

    private IRepository<Address>? _addressRepository;
    private IRepository<Author>? _authorRepository;
    private IRepository<AuthorRelation>? _authorRelationRepository;
    private IRepository<BaseEntity>? _baseEntityRepository;
    private IRepository<Book>? _bookRepository;
    private IRepository<BookQuantityRelation>? _bookQuantityRelationRepository;
    private IRepository<Genre>? _genreRepository;
    private IRepository<Library>? _libraryRepository;
    private IRepository<Publisher>? _publisherRepository;
    private IRepository<Reservation>? _reservationRepository;
    private IRepository<Review>? _reviewRepository;
    private IRepository<Role>? _roleRepository;
    private IRepository<User>? _userRepository;

    public IRepository<Address> AddressRepository => _addressRepository ??= new GenericRepository<Address>(_context);

    public IRepository<Author> AuthorRepository => _authorRepository ??= new GenericRepository<Author>(_context);

    public IRepository<AuthorRelation> AuthorRelationRepository => _authorRelationRepository ??= new GenericRepository<AuthorRelation>(_context);

    public IRepository<BaseEntity> BaseEntityRepository => _baseEntityRepository ??= new GenericRepository<BaseEntity>(_context);

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);

    public IRepository<BookQuantityRelation> BookQuantityRelationRepository => _bookQuantityRelationRepository ??= new GenericRepository<BookQuantityRelation>(_context);

    public IRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(_context);

    public IRepository<Library> LibraryRepository => _libraryRepository ??= new GenericRepository<Library>(_context);

    public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(_context);

    public IRepository<Reservation> ReservationRepository => _reservationRepository ??= new GenericRepository<Reservation>(_context);

    public IRepository<Review> ReviewRepository => _reviewRepository ??= new GenericRepository<Review>(_context);

    public IRepository<Role> RoleRepository => _roleRepository ??= new GenericRepository<Role>(_context);

    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);

    #endregion

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}