using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommand
    {
        public string Description => "Move";

        public void Execute(int number)
        {
            Console.Clear();

        }
    }
}
