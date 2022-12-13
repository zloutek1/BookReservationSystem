using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Domain
{
    public class BookProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AuthorDto Author { get; set; }
        public LibraryDto Library { get; set; }
        public PublisherDto Publisher { get; set; }
        public string Abstract { get; set; }
        public string? CoverArtPath { get; set; }
        public long Isbn { get; set; }

        public BookQuantityDto QuantityDto { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
