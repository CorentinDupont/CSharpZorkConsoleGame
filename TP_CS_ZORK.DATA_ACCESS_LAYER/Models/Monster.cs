using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dammage { get; set; }
        public int MissRate { get; set; }
        public int Hp { get; set; }
    }
}
