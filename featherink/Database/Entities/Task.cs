﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database.Entities
{
    public class Task : Entity
    {

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int DesignerId { get; set; }

        public virtual Designer Designer { get; set; }
        public virtual User User { get; set; }

    }
}
