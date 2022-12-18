using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IBookService : ICrudService<BookDto>
{
    Task<IEnumerable<BookDto>> FilterBooks(BookFilterDto filter);
    Task<BookDto?> FindByReview(Guid reviewId);
    Task Insert(BookCreateDto createDto);
    Task Update(BookUpdateDto updateDto);
    Task<IEnumerable<BookDto>> FindAllNotInLibrary(Guid libraryId);
}