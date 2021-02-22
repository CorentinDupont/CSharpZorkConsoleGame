using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    public class WeaponsTypeAccessLayer : BaseAccessLayer<WeaponsType>
    {

        private static WeaponsTypeAccessLayer instance = null;

        private WeaponsTypeAccessLayer(ZorkDbContext context) : base(context) { }

        public static WeaponsTypeAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new WeaponsTypeAccessLayer(context);
            }

            return instance;
        }
    }
}
