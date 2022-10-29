using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.DAL.Models;

public class Role : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public virtual List<User> Users { get; set; } = new List<User>();
}
