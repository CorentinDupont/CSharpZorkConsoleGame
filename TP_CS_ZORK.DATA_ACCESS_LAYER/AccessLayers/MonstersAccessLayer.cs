using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    public class MonstersAccessLayer : BaseAccessLayer<Monster>
    {

        private static MonstersAccessLayer instance = null;

        private MonstersAccessLayer(ZorkDbContext context) : base(context) {}

        public static MonstersAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var factory = new DbContextFactory();
                var context = factory.CreateDbContext(null);
                instance = new MonstersAccessLayer(context);
            }

            return instance;
        }
    }
}
