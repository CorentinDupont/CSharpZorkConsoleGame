using System;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommand
    {
        public string Description => "Move";

        public void Execute(int number)
        {
            Menu menu = new Menu(
                CommandsEnum.CmdMoveNorth.ToString(),
                CommandsEnum.CmdMoveEst.ToString(),
                CommandsEnum.CmdMoveSouth.ToString(),
                CommandsEnum.CmdMoveWest.ToString());

            Console.Clear();

            menu.Activate();


        }
    }
}
