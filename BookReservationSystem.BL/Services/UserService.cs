using AutoMapper;
using BookReservationSystem.BL.Configs;
using BookReservationSystem.BL.DTOs;
using BookReservationSystem.BL.QueryObjects;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Services
{
    public class UserService
    {
        private IMapper _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        private BookReservationSystemDbContext _context;
        private UserQueryObject _userQueryObject;
        public UserService(BookReservationSystemDbContext context)
        {
            _context = context;
        }
        public UserGetDTO GetTest()
        {
            var monkman = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Westbrook",
                LastName = "Monkman",
                Email = "wmonkman0@zdnet.com",
                Password = "RLreUYnARxnE",
                PasswordSalt = ""
            };

            return _mapper.Map<UserGetDTO>(monkman);
        }

        //get users that lent a book
    }
}
