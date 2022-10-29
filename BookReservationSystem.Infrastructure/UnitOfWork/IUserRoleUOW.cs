using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IUserRoleUOW : IDisposable
{
    IRepository<Role> RoleRepository { get; }
    IRepository<User> UserRepository { get; }
    public Task Commit();
}