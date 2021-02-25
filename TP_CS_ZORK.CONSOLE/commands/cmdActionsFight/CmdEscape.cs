using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdEscape : ICommandAsync
    {
        public new string Description => "Escape";

        public async Task ExecuteAsync(int number)
        {
            var player = await GameInstance.GetPlayerInstance();
            var currentCell = player.Cells.Single(c => c.PlayerPresence == true);
            var monster = GameInstance.GetFightingMonster();
            Random random = new Random();
            var escapeChance = random.Next(0, 100);

            if (escapeChance < monster.MissRate)
            {
                Console.WriteLine("You managed to escape the monster!");

                var previousMenu = new Menu(
                    CommandsEnum.CmdInventory.ToString(),
                    CommandsEnum.CmdStats.ToString(),
                    CommandsEnum.CmdMove.ToString(),
                    CommandsEnum.CmdExit.ToString()
                );

                Menu menu = new Menu(
                    new CmdMoveNorth(),
                    new CmdMoveEst(),
                    new CmdMoveSouth(),
                    new CmdMoveWest(),
                    new CmdGoBack(previousMenu)
                );

                await menu.Activate();
            } else
            {
                GameInstance.Fight(monster, player);
            }
        }
    }
}
