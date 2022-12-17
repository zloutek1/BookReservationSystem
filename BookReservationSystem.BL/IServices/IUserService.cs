using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IUserService
{
    Task<IEnumerable<UserDto>> FindAll();
    Task<UserDto?> FindById(Guid id);
    Task<IEnumerable<UserDto>> FilterUsers(UserFilterDto filter);
    
    Task Update(UserEditDto updateDto);
    Task Delete(Guid id);
    
}