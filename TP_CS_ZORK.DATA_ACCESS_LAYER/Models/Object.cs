using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Object
    {
        public Object()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public int? PlayerId { get; set; }

        public virtual ObjectsType IdNavigation { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
