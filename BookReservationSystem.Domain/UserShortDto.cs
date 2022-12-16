using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class UserShortDto
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
}
