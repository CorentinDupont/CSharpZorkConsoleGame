using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE
{
    class Program
    {
        static async Task Main(string[] args)
        {
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
