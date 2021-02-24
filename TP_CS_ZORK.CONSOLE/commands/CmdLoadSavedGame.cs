using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdLoadSavedGame : ICommandAsync
    {
        private PlayersAccessLayer playersAccessLayer = PlayersAccessLayer.GetInstance();

        public string Description => "Load Saved Game";

        public async Task ExecuteAsync(int number)
        {
            var players = playersAccessLayer.GetCollection().ToList();

            var menu = new Menu(players.Select(p => new CmdLoadChosenGame(p)).ToArray());
            await menu.Activate();
        }
    }
}
