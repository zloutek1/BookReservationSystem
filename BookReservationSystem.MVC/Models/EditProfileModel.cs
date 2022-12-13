using BookReservationSystem.Domain;

namespace BookReservationSystem.MVC.Models
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

        public UserProfileDto ConvertToProfileDto()
        {
            return new UserProfileDto
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Id = this.Id,
            };
        }
    }
}
