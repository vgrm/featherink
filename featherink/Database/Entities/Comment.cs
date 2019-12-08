using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database.Entities
{
    public class Comment : Entity
    {

        public Comment()
        {

        }

        public int Rating { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ArtId { get; set; }

        public virtual Art Art { get; set; }

        public virtual User User { get; set; }

    }
}
