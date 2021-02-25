using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    public class PlayersAccessLayer : BaseAccessLayer<Player>
    {

        private static PlayersAccessLayer instance = null;

        private PlayersAccessLayer(ZorkDbContext context) : base(context) {
            this.ReferenceNavigationProperties.Add("CurrentCell");
            this.CollectionNavigationProperties.Add("Cells");
            this.CollectionNavigationProperties.Add("Weapons");
        }

        public static PlayersAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new PlayersAccessLayer(context);
            }

            return instance;
        }

        public Player GetSingleWithRelations(Expression<Func<Player, bool>> filter, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var item = trackingEnabled
                ? dbQuery
                    .Include(p => p.Cells)
                    .Include(p => p.Weapons).ThenInclude(w => w.WeaponType)
                    .Include(p => p.Objects).ThenInclude(o => o.ObjectType)
                    .FirstOrDefault(filter)
                : dbQuery.AsNoTracking().FirstOrDefault(filter);

            return item;
        }
    }
}
