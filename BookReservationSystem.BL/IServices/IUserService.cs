using BookReservationSystem.Domain;
using BookReservationSystem.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.IServices
{
    public interface IUserService : ICrudService<UserProfileDto>
    {
        UserDto? FindByUsername(string username);
        void RegisterUser(UserCreateDto userCreateDto);
    }
}
