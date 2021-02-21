using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Weapon
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int WeaponTypeId { get; set; }

        public virtual Player Player { get; set; }
        public virtual WeaponsType WeaponType { get; set; }
    }
}
