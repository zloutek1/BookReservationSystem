using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Role : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public virtual List<User> Users { get; set; } = new List<User>();
}