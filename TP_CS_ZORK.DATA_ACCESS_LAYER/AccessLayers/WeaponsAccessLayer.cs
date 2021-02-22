using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    class WeaponsAccessLayer : BaseAccessLayer<Weapon>
    {

        private static WeaponsAccessLayer instance = null;

        private WeaponsAccessLayer(ZorkDbContext context) : base(context) { }

        public static WeaponsAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new WeaponsAccessLayer(context);
            }

            return instance;
        }
    }
}
