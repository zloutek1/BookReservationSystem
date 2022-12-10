using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class LoginDto
{
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}