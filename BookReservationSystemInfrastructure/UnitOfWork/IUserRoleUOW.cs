using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IUserRoleUOW : IDisposable
{
    IRepository<Role> RoleRepository { get; }
    IRepository<User> UserRepository { get; }
    public Task Commit();
}