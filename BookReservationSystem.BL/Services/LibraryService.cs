using AutoMapper;
using BookReservationSystem.BL.Configs;
using BookReservationSystem.BL.QueryObjects;
using BookReservationSystem.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Services
{
    public class LibraryService
    {
        private IMapper _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        private BookReservationSystemDbContext _context;
        private LibraryQueryObject _libraryQueryObject;
        public LibraryService(BookReservationSystemDbContext context)
        {
            _context = context;
        }
    }
}
