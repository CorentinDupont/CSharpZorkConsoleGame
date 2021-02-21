using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.maps;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMoveEst : ICommand
    {
        public string Description => "Move to est";

        public void Execute(int number)
        {
            Player player = Player.GetInstance();

            Cell currentCellPlayer = player.GetCurrentCell(player.currentCellId);

            int newPosition = currentCellPlayer.posX + 1;

            // Check if player in on the border
            if (newPosition < player.currentMap.GetLongLength(0))
            {
                Cell estCellPlayer = (Cell)player.currentMap.GetValue(newPosition, currentCellPlayer.posY);

                // Check if the next cell is a wall
                if (estCellPlayer.canMoveTo == true)
                {

                        MenuMove();

                        Random random = new Random();
                        int spawnMonster = random.Next(0, 100);  // creates a number between 5 and 20
                        if (spawnMonster < estCellPlayer.monsterRate)
                        {
                            Monster monster = new Monster(estCellPlayer.id); ;
                            player.GetCurrentCell(player.currentCellId).currentMonster = monster;
                            Fight(monster, player);
                        }

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
            player.currentCellId = newCell.id;
            Console.WriteLine($"newCellPlayer.posX:  {newCell.posX}");
            Console.WriteLine($"newCellPlayer.posY:  {newCell.posY}");
            Console.WriteLine($"You are on a :  {newCell.description}");
            Console.ReadLine();
        }

        public void Fight(Monster monster, Player player)
        {
            Console.WriteLine($"You are attacked by a {monster.name} !");
            player.hp -= monster.damages;
            Console.WriteLine($"You take {monster.damages}, you still have {player.hp} !");
            Console.WriteLine($"What do you want to do ?");
            
            new Menu(
            CommandsEnum.CmdHit.ToString(),
            CommandsEnum.CmdUseObject.ToString(),
            CommandsEnum.CmdEscape.ToString());
        }
    }
}
