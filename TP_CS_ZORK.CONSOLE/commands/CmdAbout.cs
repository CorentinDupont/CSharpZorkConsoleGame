﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdAbout : ICommand
    {
        public string Description => "About";

        public void Execute(int number)
        {}
    }
}
