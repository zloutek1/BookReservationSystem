using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class GenreDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
}
