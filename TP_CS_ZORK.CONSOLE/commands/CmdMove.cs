using System;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommand
    {
        public string Description => "Move";

        public void Execute(int number)
        {
            MenuMove();
        }

        public void MovePlayer(Player player, Cell newCell)
        {
            player.CurrentCell = newCell;
            Console.WriteLine($"newCellPlayer.posX:  {newCell.PosX}");
            Console.WriteLine($"newCellPlayer.posY:  {newCell.PosY}");
            Console.WriteLine($"You are on a :  {newCell.Description}");
            Console.ReadLine();

            MenuMove();
        }

        public async void MenuMove()
        {
            Menu menu = new Menu(
                    CommandsEnum.CmdMoveNorth.ToString(),
                    CommandsEnum.CmdMoveEst.ToString(),
                    CommandsEnum.CmdMoveWest.ToString(),
                    CommandsEnum.CmdMoveSouth.ToString());

            await menu.Activate();
        }

        public void Blocked(Cell cell)
        {
            Console.WriteLine($"This case is inaccessible ! It is a {cell.Description}");
            Console.ReadLine();
            MenuMove();
        }

        public void Blocked()
        {
            Console.WriteLine($"You are on the limit of the map!");
            Console.ReadLine();
            MenuMove();
        }


    }
}
