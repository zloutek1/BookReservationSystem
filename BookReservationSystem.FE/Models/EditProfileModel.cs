using BookReservationSystem.Domain;

namespace BookReservationSystem.FE.Models
{
    public class EditProfileModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public EditProfileModel() { }

        public EditProfileModel(UserDto userDto)
        {
            FirstName = userDto.FirstName;
            Email = userDto.Email;
            LastName = userDto.LastName;
            Id = userDto.Id;
        }
    }
}
