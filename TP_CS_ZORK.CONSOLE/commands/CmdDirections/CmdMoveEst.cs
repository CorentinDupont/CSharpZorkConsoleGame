using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMoveEst : ICommand
    {
        public string Description => "Move to est";

        public void Execute(int number)
        {
            Player player = GameInstance.GetPlayerInstance();


            // Check if next cell in not the border
            int newPosition = player.CurrentCell.PosX + 1;
            if (newPosition < player.Cells.Last().PosX)
            {
                // Check if the next cell is a wall
                Cell estCellPlayer = GameInstance.GetNextCell("est");
                if (estCellPlayer.CanMoveTo == true)
                {

                        MovePlayer(player, estCellPlayer);

                        // Check if a monster spawn
                        Random random = new Random();
                        int spawnMonster = random.Next(0, 100);  // creates a number between 5 and 20
                        if (spawnMonster < estCellPlayer.MonsterRate)
                        {
                            //Monster monster = new Monster(estCellPlayer.id);
                            //player.GetCurrentCell(player.currentCellId).currentMonster = monster;
                            //Fight(monster, player);
                        }

                    // Check if an item spawn

                    // Check if an event spawn



                }
                else
                {
                    Console.WriteLine($"This case is inaccessible !");
                    Console.ReadLine();
                    MenuMove();

                }
            } else
            {

                Console.WriteLine($"You are on the limit of the map!");
                Console.ReadLine();
                MenuMove();
            }
        }

        public void MenuMove()
        {
            new Menu(
                    CommandsEnum.CmdMoveNorth.ToString(),
                    CommandsEnum.CmdMoveEst.ToString(),
                    CommandsEnum.CmdMoveWest.ToString(),
                    CommandsEnum.CmdMoveSouth.ToString());
        }

        public void MovePlayer(Player player, Cell newCell)
        {
            player.CurrentCell = newCell;
            Console.WriteLine($"newCellPlayer.posX:  {newCell.PosX}");
            Console.WriteLine($"newCellPlayer.posY:  {newCell.PosY}");
            Console.WriteLine($"You are on a :  {newCell.Description}");
            Console.ReadLine();
        }

        public void Fight(Monster monster, Player player)
        {
            Console.WriteLine($"You are attacked by a {monster.Name} !");
            player.Hp -= monster.Damage;
            Console.WriteLine($"You take {monster.Damage}, you still have {player.Hp} !");
            Console.WriteLine($"What do you want to do ?");

            while(player.Hp != 0 || monster.Hp != 0)
            {
                new Menu(
                CommandsEnum.CmdHit.ToString(),
                CommandsEnum.CmdUseObject.ToString(),
                CommandsEnum.CmdEscape.ToString());
            }
            
            
        }
    }
}
