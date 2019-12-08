using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database.Entities
{
    public class Art : Entity
    {
        public Art()
        {

        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int DesignerId { get; set; }

        public virtual Designer Designer { get; set; }


    }
}
