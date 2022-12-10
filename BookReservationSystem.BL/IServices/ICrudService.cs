namespace BookReservationSystem.BL.IServices;

public interface ICrudService<TDto>
{
    IEnumerable<TDto> FindAll();
    TDto? FindById(Guid id);
    void Insert(TDto dto);
    void Update(TDto dto);
    void Delete(Guid id);
}