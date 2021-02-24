using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdStats : ICommandAsync
    {
        public string Description => "Stats";

        public async Task ExecuteAsync(int number)
        {
            var player = await GameInstance.GetPlayerInstance();

            Console.WriteLine("Stats: ");
            Console.WriteLine($"HP: {player.Hp}/{player.MaxHp}");
            Console.WriteLine($"Current coordinates: x:{player.CurrentCell.PosX} y:{player.CurrentCell.PosY}");

            Console.ReadLine();

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
