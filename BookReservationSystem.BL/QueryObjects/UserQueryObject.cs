using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookReservationSystem.BL.DTOs;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Query;

namespace BookReservationSystem.BL.QueryObjects
{
    internal class UserQueryObject
    {
        private IMapper _mapper;

        private GenericQuery<User> _query;

        public UserQueryObject(IMapper mapper, BookReservationSystemDbContext context)
        {
            _mapper = mapper;
            _query = new GenericQuery<User>(context);
        }

        //add execute
        //do I even need use query object wtf
    }
}
