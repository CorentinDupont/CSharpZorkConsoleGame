using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(
                CommandsEnum.CmdCreateNewGame.ToString(), 
                CommandsEnum.CmdLoadSavedGame.ToString(), 
                CommandsEnum.CmdAbout.ToString(), 
                CommandsEnum.CmdExit.ToString());
     
        }
    }
}
