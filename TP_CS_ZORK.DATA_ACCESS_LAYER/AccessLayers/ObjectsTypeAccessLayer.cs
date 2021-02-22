using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    public class ObjectsTypeAccessLayer : BaseAccessLayer<ObjectsType>
    {

        private static ObjectsTypeAccessLayer instance = null;

        private ObjectsTypeAccessLayer(ZorkDbContext context) : base(context) { }

        public static ObjectsTypeAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new ObjectsTypeAccessLayer(context);
            }

            return instance;
        }
    }
}
