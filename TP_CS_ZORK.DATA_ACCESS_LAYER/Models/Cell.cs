﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Cell : BaseDataObject
    {
        public Cell()
        {
            Players = new HashSet<Player>();
        }

        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool CanMoveTo { get; set; }
        public int MonsterRate { get; set; }
        public int ItemRate { get; set; }
        public string Description { get; set; }

        public bool? PlayerPresence { get; set; }
        public int? PlayerId { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
