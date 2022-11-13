using AutoMapper;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystem.Infrastructure.EFCore.Query;

namespace BookReservationSystem.BL.QueryObjects
{
    public class LibraryQueryObject
    {
        private IMapper _mapper;

        private GenericQuery<Library> _query;

        public LibraryQueryObject(IMapper mapper, BookReservationSystemDbContext context)
        {
            _mapper = mapper;
            _query = new GenericQuery<Library>(context);
        }

        //add execute
    }
}
