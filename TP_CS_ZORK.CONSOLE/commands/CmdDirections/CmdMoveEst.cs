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

            //Console.WriteLine($"currentCellPlayer.posX:  {currentCellPlayer.posX}");
            //Console.WriteLine($"currentCellPlayer.posY:  {currentCellPlayer.posY}");
            //Console.WriteLine($"currentCellPlayer.id:  {currentCellPlayer.id}");
            //Console.WriteLine($"currentCellPlayer.description:  {currentCellPlayer.description}");

            int newPosition = currentCellPlayer.posX + 1;

            // Check if player in on the border
            if (newPosition < player.currentMap.GetLongLength(0))
            {
                Cell estCellPlayer = (Cell)player.currentMap.GetValue(newPosition, currentCellPlayer.posY);

                // Check if the next cell is a wall
                if (estCellPlayer.canMoveTo == true)
                {
                    player.currentCellId = estCellPlayer.id;

                    Cell newCellPlayer = player.GetCurrentCell(player.currentCellId);

                    Console.WriteLine($"newCellPlayer.posX:  {newCellPlayer.posX}");
                    Console.WriteLine($"newCellPlayer.posY:  {newCellPlayer.posY}");
                    //Console.WriteLine($"newCellPlayer.id:  {newCellPlayer.id}");
                    Console.WriteLine($"newCellPlayer.description:  {newCellPlayer.description}");
                    Console.ReadLine();
                    new Menu(
                        CommandsEnum.CmdMoveNorth.ToString(),
                        CommandsEnum.CmdMoveEst.ToString(),
                        CommandsEnum.CmdMoveWest.ToString(),
                        CommandsEnum.CmdMoveSouth.ToString());
                }
                else
                {
                    Console.WriteLine($"This case is inaccessible !");
                    Console.ReadLine();
                    new Menu(
                        CommandsEnum.CmdMoveNorth.ToString(),
                        CommandsEnum.CmdMoveEst.ToString(),
                        CommandsEnum.CmdMoveWest.ToString(),
                        CommandsEnum.CmdMoveSouth.ToString());
                }
            } else
            {

                Console.WriteLine($"You are on the limit of the map!");
                Console.ReadLine();
                new Menu(
                    CommandsEnum.CmdMoveNorth.ToString(),
                    CommandsEnum.CmdMoveEst.ToString(),
                    CommandsEnum.CmdMoveWest.ToString(),
                    CommandsEnum.CmdMoveSouth.ToString());
            }
        
        }
    }
}
