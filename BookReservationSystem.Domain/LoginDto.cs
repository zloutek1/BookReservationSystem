using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class LoginDto
{
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;
    
    public string? ReturnUrl { get; set; }
}