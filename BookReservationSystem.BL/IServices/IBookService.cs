using BookReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.IServices
{
    public interface IBookService : ICrudService<BookDto>
    {
        IEnumerable<BookDto> FilterBooks(BookFilterDto filter);
    }
}
