﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdLoadChosenGame : ICommandAsync
    {
        private readonly Player player;

        public string Description => this.player.Name;

        public CmdLoadChosenGame(Player player)
        {
            this.player = player;
        }

        public async Task ExecuteAsync(int number)
        {
            GameInstance.SetPlayerInstance(player.Id);

            // Display game
            var menu = new Menu(
                CommandsEnum.CmdInventory.ToString(),
                CommandsEnum.CmdStats.ToString(),
                CommandsEnum.CmdMove.ToString(),
                CommandsEnum.CmdExit.ToString());

            await menu.Activate();
        }
    }
}
