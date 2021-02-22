using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMoveSouth : ICommand
    {
        public string Description => "Move to south";

        public void Execute(int number)
        {
            //Player player = Player.GetInstance();

            //Cell currentCellPlayer = player.GetCurrentCell(player.currentCellId);

            ////Console.WriteLine($"currentCellPlayer.posX:  {currentCellPlayer.posX}");
            ////Console.WriteLine($"currentCellPlayer.posY:  {currentCellPlayer.posY}");
            ////Console.WriteLine($"currentCellPlayer.id:  {currentCellPlayer.id}");
            ////Console.WriteLine($"currentCellPlayer.description:  {currentCellPlayer.description}");

            //int newPosition = currentCellPlayer.posY - 1;
            //Cell estCellPlayer = (Cell)player.currentMap.GetValue(newPosition, currentCellPlayer.posY);

            //if (estCellPlayer.canMoveTo == true)
            //{
            //    player.currentCellId = estCellPlayer.id;

            //    Cell newCellPlayer = player.GetCurrentCell(player.currentCellId);

            //    Console.WriteLine($"newCellPlayer.posX:  {newCellPlayer.posX}");
            //    Console.WriteLine($"newCellPlayer.posY:  {newCellPlayer.posY}");
            //    Console.WriteLine($"newCellPlayer.id:  {newCellPlayer.id}");
            //    Console.WriteLine($"newCellPlayer.description:  {newCellPlayer.description}");
            //    Console.ReadLine();
            //    new Menu(
            //        CommandsEnum.CmdMoveNorth.ToString(),
            //        CommandsEnum.CmdMoveEst.ToString(),
            //        CommandsEnum.CmdMoveWest.ToString(),
            //        CommandsEnum.CmdMoveSouth.ToString());
            //}
            //else
            //{
            //    Console.WriteLine($"This case is inaccessible !");
            //    Console.ReadLine();
            //    new Menu(
            //        CommandsEnum.CmdMoveNorth.ToString(),
            //        CommandsEnum.CmdMoveEst.ToString(),
            //        CommandsEnum.CmdMoveWest.ToString(),
            //        CommandsEnum.CmdMoveSouth.ToString());
            //}

        }
    }
}
