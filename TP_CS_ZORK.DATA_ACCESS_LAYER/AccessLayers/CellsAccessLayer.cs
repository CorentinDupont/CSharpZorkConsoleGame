using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    class CellsAccessLayer : BaseAccessLayer<Cell>
    {

        private static CellsAccessLayer instance = null;

        private CellsAccessLayer(ZorkDbContext context) : base(context) { }

        public static CellsAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new CellsAccessLayer(context);
            }

            return instance;
        }
    }
}
