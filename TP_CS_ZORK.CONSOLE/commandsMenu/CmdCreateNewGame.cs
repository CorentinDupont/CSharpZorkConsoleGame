﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdCreateNewGame : ICommand
    {
        public string Description => "Create new game";

        public void Execute(int number)
        {
            Console.WriteLine("Enter your name!");
            Console.WriteLine("\n");
            string userName = Console.ReadLine();

            Console.WriteLine("\n\n\n");
        }
    }
}