using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdEscape : ICommand
    {
        public new string Description => "Escape";

        public void Execute(int number)
        {
            var monster = GameInstance.GetFightingMonster();

            Random random = new Random();
            var escapeChance = random.Next(0, 100);
            var escapeRate = monster.MissRate * 2;

            if (escapeChance < escapeRate)
            {
                Console.WriteLine("You managed to escape the monster!");

                GameInstance.isPlayerFighting = false;
            } else
            {
                Console.WriteLine("You failed to escape the monster ...");
            }
        }
    }
}
