using System;
using System.Collections.Generic;

#nullable disable

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public partial class Object
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int ObjectTypeId { get; set; }

        public virtual ObjectsType ObjectType { get; set; }
        public virtual Player Player { get; set; }
    }
}
