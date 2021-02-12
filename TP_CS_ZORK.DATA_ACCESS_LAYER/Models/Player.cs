using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Exp { get; set; }
        public int? Hp { get; set; }
        public int? MaxHp { get; set; }
        public int? CurrentCellId { get; set; }
        public int? WeaponsId { get; set; }
        public int? ObjectsId { get; set; }

        public virtual Cell CurrentCell { get; set; }
        public virtual Object Objects { get; set; }
        public virtual Weapon Weapons { get; set; }
    }
}
