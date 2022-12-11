using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Domain
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public virtual IEnumerable<ReviewDto> Reviews { get; set; }
        public virtual IEnumerable<ReservationDto> Reservations { get; set; }
    }
}
