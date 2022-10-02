﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
