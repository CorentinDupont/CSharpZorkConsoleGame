using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommand
    {
        public string Description => "Move";

        public void Execute(int number)
        {
            new Menu(
                CommandsEnum.CmdMoveNorth.ToString(),
                CommandsEnum.CmdMoveEst.ToString(),
                CommandsEnum.CmdMoveSouth.ToString(),
                CommandsEnum.CmdMoveWest.ToString());

            Console.Clear();

        }
    }
}
