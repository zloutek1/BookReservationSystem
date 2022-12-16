namespace BookReservationSystem.BL.IServices;

public interface ICrudService<TDto>
{
    Task<IEnumerable<TDto>> FindAll();
    Task<TDto?> FindById(Guid id);
    Task Insert(TDto createDto);
    Task Update(TDto updateDto);
    Task Delete(Guid id);
}