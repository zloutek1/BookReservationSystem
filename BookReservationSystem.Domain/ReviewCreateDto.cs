using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Domain
{
    public class ReviewCreateDto
    {
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string Content { get; set; } = null!;

        [Required]
        public Guid BookId { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

    }
}
