using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IBookQuantityService
{
    Task<BookQuantityDto?> FindById(Guid libraryId, Guid bookId);
    Task Insert(BookQuantityCreateDto createDto);
    Task Update(BookQuantityCreateDto updateDto);
    Task Delete(Guid libraryId, Guid bookId);
}