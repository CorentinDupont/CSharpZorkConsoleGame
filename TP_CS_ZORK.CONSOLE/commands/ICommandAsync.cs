﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    interface ICommandAsync : IBaseCommand
    {
        public Task ExecuteAsync(int number);
    }
}
