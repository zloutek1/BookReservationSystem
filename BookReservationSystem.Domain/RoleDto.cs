using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class RoleDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
}
