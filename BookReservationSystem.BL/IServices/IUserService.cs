using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IUserService : ICrudService<UserDto>
{
    Task<IEnumerable<UserDto>> FilterUsers(UserFilterDto filter);
    new Task Update(UserDto updateDto);
}