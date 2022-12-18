using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class UserDto
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(64)]
    [Display(Name = "Firstname")]
    public string FirstName { get; set; } = null!;

    [Required] 
    [StringLength(64)]
    [Display(Name = "Lastname")]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(64)]
    [Display(Name = "Username")]
    public string UserName { get; set; } = null!;

    [Required] 
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = null!;
    
    [Required]
    public virtual IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    
    [Required]
    public virtual IEnumerable<ReservationDto> Reservations { get; set; } = new List<ReservationDto>();
}
