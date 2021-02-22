﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    class PlayersAccessLayer : BaseAccessLayer<Player>
    {

        private static PlayersAccessLayer instance = null;

        private PlayersAccessLayer(ZorkDbContext context) : base(context) { }

        public static PlayersAccessLayer GetInstance()
        {
            if (instance == null)
            {
                var context = DbContextStore.GetInstance().dbContext;
                instance = new PlayersAccessLayer(context);
            }

            return instance;
        }
    }
}