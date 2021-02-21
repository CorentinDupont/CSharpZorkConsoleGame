using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    class MonstersAccessLayer : BaseAccessLayer<Monster>
    {

        public MonstersAccessLayer(ZorkDbContext context) : base(context) {}
    }
}
