using BookReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.IServices
{
    public interface IReviewService : ICrudService<ReviewDto>
    {
        Task Insert(ReviewCreateDto reviewCreateDto);
        Task<IEnumerable<ReviewDto>> FindAllFromUser(Guid userId);
        Task<IEnumerable<ReviewDto>> FindAllForBook(Guid bookId);
    }
}
