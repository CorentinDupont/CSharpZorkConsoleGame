using System;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommandAsync
    {
        public string Description => "Move";

        public async Task ExecuteAsync(int number)
        {
            await MenuMove();
        }

        public void MovePlayer(Player player, Cell newCell)
        {
            player.CurrentCell = newCell;
            Console.WriteLine($"newCellPlayer.posX:  {newCell.PosX}");
            Console.WriteLine($"newCellPlayer.posY:  {newCell.PosY}");
            Console.WriteLine($"You are on a :  {newCell.Description}");
            Console.ReadLine();
        }

        public async Task MenuMove()
        {
            Menu menu = new Menu(
                    new CmdMoveNorth(),
                    new CmdMoveEst(),
                    new CmdMoveSouth(),
                    new CmdMoveWest());

            await menu.Activate();
        }

        public async Task Blocked(Cell cell)
        {
            Console.WriteLine($"This case is inaccessible ! It is a {cell.Description}");
            Console.ReadLine();
            await MenuMove();
        }

        public async Task Blocked()
        {
            Console.WriteLine($"You are on the limit of the map!");
            Console.ReadLine();
            await MenuMove();
        }


    }
}
