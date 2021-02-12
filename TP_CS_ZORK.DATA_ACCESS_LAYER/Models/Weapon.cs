using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public int PlayerId { get; set; }

        public virtual WeaponsType WeaponsType { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
