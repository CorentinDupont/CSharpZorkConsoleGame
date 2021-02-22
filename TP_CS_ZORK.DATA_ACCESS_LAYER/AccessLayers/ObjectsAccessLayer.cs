
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    class ObjectsAccessLayer : BaseAccessLayer<Cell>
    {

        private static ObjectsAccessLayer instance = null;

        private ObjectsAccessLayer(ZorkDbContext context) : base(context) { }

        public static ObjectsAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new ObjectsAccessLayer(context);
            }

            return instance;
        }
    }
}
