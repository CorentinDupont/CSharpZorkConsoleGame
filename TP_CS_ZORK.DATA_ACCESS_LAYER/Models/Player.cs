using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Player : BaseDataObject
    {
        public Player()
        {
            Cells = new HashSet<Cell>();
            Objects = new HashSet<Object>();
            Weapons = new HashSet<Weapon>();
        }

        public string Name { get; set; }
        public int Exp { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int? CurrentCellId { get; set; }

        public virtual Cell CurrentCell { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
        public virtual ICollection<Object> Objects { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
