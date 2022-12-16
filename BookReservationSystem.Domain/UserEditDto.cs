using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class UserEditDto
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
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(@"([a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+).*", ErrorMessage = "The password is not complex enough")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}
