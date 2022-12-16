using BookReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.IServices
{
    public interface IReservationService : ICrudService<ReservationDto>
    {
        Task Insert(ReservationCreateDto createDto);
        Task PickupBook(Guid reservationId);
        Task ReturnBook(Guid reservationId);
        IEnumerable<ReservationDto> FindAllForUser(string email);
    }
}
