using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class User : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(64)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(64)]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(128)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string PasswordSalt { get; set; }

    public virtual List<Role> Roles { get; set; } = new List<Role>();
}