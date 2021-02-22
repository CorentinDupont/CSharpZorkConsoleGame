using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER
{
    class DbContextStore
    {
        private static DbContextStore instance = null;
        public ZorkDbContext dbContext = null;

        private DbContextStore() {
            var factory = new DbContextFactory();
            var context = factory.CreateDbContext(null);
            this.dbContext = context;
        }

        public static DbContextStore GetInstance()
        {
            if (instance == null)
            {
                instance = new DbContextStore();
            }

            return instance;
        }
    }
}
