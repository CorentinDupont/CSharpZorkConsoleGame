﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdExit : ICommand
    {
        public string Description => "Exit";

        public void Execute(int number)
        {
            Environment.Exit(0);
        }
    }
}
