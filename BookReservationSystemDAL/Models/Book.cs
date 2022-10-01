using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class Book : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Abstract { get; set; }

        [MaxLength(256)]
        public string CoverArtUrl { get; set; }

        public long ISBN { get; set; }

        public virtual List<Genre> Genres { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }

        public Guid PublisherId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public virtual Publisher Publisher { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}
