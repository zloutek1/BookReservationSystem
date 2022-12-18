using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IReservationService : ICrudService<ReservationDto>
{
    Task Insert(ReservationCreateDto createDto);
    Task PickupBook(Guid reservationId);
    Task ReturnBook(Guid reservationId);
}