using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Query;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.BL.DTOs;

namespace BookReservationSystem.BL.QueryObjects
{
    public class BookQueryObject
    {
        private IMapper _mapper;

        private GenericQuery<Book> _query;

        public BookQueryObject(IMapper mapper, BookReservationSystemDbContext context)
        {
            _mapper = mapper;
            _query = new GenericQuery<Book>(context);
        }

        //add execute
    }
}
