using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IUserRoleUOW : IDisposable
    {
        IRepository<Role> RoleRepository { get; }
        IRepository<User> UserRepository { get; }
        public Task Commit();
    }
}
