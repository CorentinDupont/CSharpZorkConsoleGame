using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMoveSouth : CmdMove, ICommand
    {
        public string Description => "Move to south";

        public void Execute(int number)
        {
            Player player = GameInstance.GetPlayerInstance();

            // Check if next cell in not the border
            int newPosition = player.CurrentCell.PosY - 1;
            if (newPosition >= player.Cells.First().PosY)
            {
                // Check if the next cell is a wall
                Cell nextCell = GameInstance.GetNextCell("south");
                if (nextCell.CanMoveTo == true)
                {

                    MovePlayer(player, nextCell);

                    // Check if a monster spawn
                    Random random = new Random();
                    int spawnMonster = random.Next(0, 101);
                    if (spawnMonster < nextCell.MonsterRate)
                    {
                        GameInstance.Fight(GameInstance.SummonMonster("Vilain"), player);
                    } else if (spawnMonster >= 90 && spawnMonster <= 100)
                    {
                        GameInstance.Fight(GameInstance.SummonMonster("Grand mechant"), player);
                    }

                    MenuMove();

                    // Check if an item spawn

                    // Check if an event spawn
                }
                else
                {
                    Blocked(nextCell);
                }
            }
            else
            {
                Blocked();
            }
        }
    }
}
