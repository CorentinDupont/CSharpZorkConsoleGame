using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMoveNorth : CmdMove, ICommandAsync
    {
        public new string Description => "Move to north";

        public async new Task ExecuteAsync(int number)
        {
            Player player = await GameInstance.GetPlayerInstance();

            // Check if next cell in not the border
            Cell currentCell = player.Cells.Where(c => c.PlayerPresence == true).First();
            int newPosition = currentCell.PosY + 1;
            if (newPosition <= player.Cells.Last().PosY)
            {
                // Check if the next cell is a wall
                Cell nextCell = GameInstance.GetNextCell("north");
                if (nextCell.CanMoveTo == true)
                {

                    await MovePlayer(nextCell);

                    // Check if a monster spawn
                    Random random = new Random();
                    int spawnMonster = random.Next(0, 100);  // creates a number between 5 and 20
                    if (spawnMonster < nextCell.MonsterRate)
                    {
                        GameInstance.Fight(GameInstance.SummonMonster("Vilain"), player);
                    }
                    else if (spawnMonster >= 90 && spawnMonster <= 100)
                    {
                        GameInstance.Fight(GameInstance.SummonMonster("Grand mechant"), player);
                    }
                    await MenuMove();

                    // Check if an item spawn

                    // Check if an event spawn
                }
                else
                {
                    await Blocked(nextCell);
                }
            }
            else
            {
                await Blocked();
            }
        }
    }
}
