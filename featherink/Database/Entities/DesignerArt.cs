using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database.Entities
{
    public class DesignerArt : Entity
    {
        public int ArtId { get; set; }
        public int DesignerId { get; set; }

        public virtual Designer Designer { get; set; }
        public virtual Art Art { get; set; }

    }
}
