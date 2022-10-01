using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
