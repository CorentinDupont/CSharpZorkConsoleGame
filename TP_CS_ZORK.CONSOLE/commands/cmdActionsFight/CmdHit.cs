using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.CONSOLE.weapons;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdHit : ICommand
    {
        public string Description => "Hit";

        public void Execute(int number)
        {
            
            Player player = GameInstance.GetPlayerInstance();

            Monster monster = GameInstance.GetFightingMonster();
            int damagesMade = player.Weapons.First().WeaponType.Damage;
            monster.Hp -= damagesMade;
            
            if (monster.Hp > 0)
            {
                Console.WriteLine($"You inflicted {damagesMade} damages to {monster.Name}, he has {monster.Hp} lifes left");
            } else
            {
                Console.WriteLine($"You inflicted {damagesMade} damages to {monster.Name}, he is dead");
                if (monster.Name == "Vilain")
                {
                    player.Hp += 10;
                    Console.WriteLine($"You recovered 10 life points");
                } else if (monster.Name == "Grand mechant")
                {
                    player.Hp += 115;
                    Console.WriteLine($"You recovered 115 life points");
                }

            }
            Console.ReadLine();

        }
    }
}
