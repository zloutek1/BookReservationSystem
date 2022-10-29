using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class UserRoleUOW : IUserRoleUOW
{
    private readonly BookReservationSystemDbContext _context;
    private IRepository<Role>? _roleRepository;
    private IRepository<User>? _userRepository;
        
    public UserRoleUOW(BookReservationSystemDbContext context)
    {
        _context = context;
    }

    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);
    public IRepository<Role> RoleRepository => _roleRepository ??= new GenericRepository<Role>(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}