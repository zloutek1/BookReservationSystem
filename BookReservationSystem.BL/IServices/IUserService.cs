using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IUserService
{
    Task<IEnumerable<UserDto>> FindAll();
    Task<UserDto?> FindById(Guid id);
    Task<UserDto?> FindByUsername(string username);
    
    Task Update(UserEditDto updateDto);
    Task Delete(Guid id);
    
}