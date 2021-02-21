using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdLoadSavedGame : ICommand
    {
        public string Description => "Load saved game";

        public void Execute(int number)
        {}
    }
}
