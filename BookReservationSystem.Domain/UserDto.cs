namespace BookReservationSystem.Domain;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
    public virtual IEnumerable<ReviewDto> Reviews { get; set; }
    public virtual IEnumerable<ReservationDto> Reservations { get; set; }
}
