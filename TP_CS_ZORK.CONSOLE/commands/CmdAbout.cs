using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdAbout : ICommandAsync
    {
        public string Description => "About";

        public async Task ExecuteAsync(int number)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Dupont Corentin \n");
            Console.WriteLine("Lerenard Charly \n");
            Console.WriteLine("\n\n\n");
            
            Console.WriteLine("Press any key to back to the main menu \n");

            Console.ReadLine();

            var menu = new Menu(
                CommandsEnum.CmdCreateNewGame.ToString(),
                CommandsEnum.CmdLoadSavedGame.ToString(),
                CommandsEnum.CmdAbout.ToString(),
                CommandsEnum.CmdExit.ToString()
            );

            await menu.Activate();
        }
    }
}
