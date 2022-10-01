using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class User : BaseEntity
    {
        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(128)]
        public string Password { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}
