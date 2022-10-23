using BookReservationSystemDAL.Data;
using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Repository;
using BookReservationSystemInfrastructure.Repository;
using BookReservationSystemInfrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.EFCore.UnitOfWork
{
    public class UserRoleUOW : IUserRoleUOW
    {
        private readonly BookReservationSystemDbContext _context;
        private IRepository<Role>? _roleRepository;
        private IRepository<User>? _userRepository;

        public UserRoleUOW()
        {
            _context = new BookReservationSystemDbContext();
        }

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
}
