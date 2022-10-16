using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class Library : BaseEntity
    {
        public string Name { get; set;}

        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        public virtual List<Book> Books { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
