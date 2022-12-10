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
        IEnumerable<ReservationDto> FindAllForUser(string email);
    }
}
