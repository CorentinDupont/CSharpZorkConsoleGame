﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class ObjectsType : BaseDataObject
    {
        public ObjectsType()
        {
            Objects = new HashSet<Object>();
        }

        public int Damage { get; set; }
        public int Heal { get; set; }
        public int MissRate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
