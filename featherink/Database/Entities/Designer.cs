using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featherink.Database.Entities
{
    public class Designer : Entity
    {

        //public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<DesignerArt> Arts { get; set; }
    }
}
