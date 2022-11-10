using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class UserRoleUnitOfWork : GenericUnitOfWork, IUserRoleUnitOfWork
{
    private IRepository<Role>? _roleRepository;
    private IRepository<User>? _userRepository;
        
    public UserRoleUnitOfWork(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(Context);
    public IRepository<Role> RoleRepository => _roleRepository ??= new GenericRepository<Role>(Context);
}