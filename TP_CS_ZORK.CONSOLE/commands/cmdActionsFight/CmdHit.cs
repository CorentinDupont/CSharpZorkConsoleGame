using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.maps;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.CONSOLE.weapons;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdHit : ICommand
    {
        public string Description => "Hit";

        public void Execute(int number)
        {
            
            Player player = Player.GetInstance();
            Monster fightedMonster = player.GetCurrentCell(player.currentCellId).currentMonster;

            foreach (Weapon weapon in Player.weapons)
            {
                new Menu(weapon.name);
            }
             

        }
    }
}
