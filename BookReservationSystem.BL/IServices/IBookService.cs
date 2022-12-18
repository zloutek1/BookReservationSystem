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
        Task<IEnumerable<BookDto>> FilterBooks(BookFilterDto filter);
        Task<BookDto> FindByReview(Guid reviewId);
        Task Insert(BookCreateDto createDto);
    }
}
