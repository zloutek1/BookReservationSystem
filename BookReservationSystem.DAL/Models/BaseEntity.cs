using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.DAL.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
