using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database
{
    public class Comment
    {

        public Comment()
        {

        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int DesignerId { get; set; }

        //public virtual Designer Designer { get; set; }

    }
}
