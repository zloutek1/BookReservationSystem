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
        IEnumerable<BookDto> FilterBooks(string name, string author, long isbn, string publisher, string genre, bool sortByRating, bool onlyAvailable);
    }
}
