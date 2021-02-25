using System;
using System.Linq;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdMove : ICommandAsync
    {
        public string Description => "Move";

        private readonly CellsAccessLayer cellsAccessLayer = CellsAccessLayer.GetInstance();

        public async Task ExecuteAsync(int number)
        {
            await MenuMove();
        }

        public async Task MovePlayer(Cell newCell)
        {
            var player = await GameInstance.GetPlayerInstance();

            var currentCell = player.Cells.Single(c => c.PlayerPresence == true);
            currentCell.PlayerPresence = false;
            await cellsAccessLayer.UpdateAsync(currentCell);

            newCell.PlayerPresence = true;
            await cellsAccessLayer.UpdateAsync(newCell);

            Console.WriteLine($"newCellPlayer.posX:  {newCell.PosX}");
            Console.WriteLine($"newCellPlayer.posY:  {newCell.PosY}");
            Console.WriteLine($"You are on a :  {newCell.Description}");
            Console.ReadLine();
        }

        public async Task MenuMove()
        {
            var previousMenu = new Menu(
                CommandsEnum.CmdInventory.ToString(),
                CommandsEnum.CmdStats.ToString(),
                CommandsEnum.CmdMove.ToString(),
                CommandsEnum.CmdExit.ToString()
            );

            Menu menu = new Menu(
                new CmdMoveNorth(),
                new CmdMoveEst(),
                new CmdMoveSouth(),
                new CmdMoveWest(),
                new CmdGoBack(previousMenu)
            );

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
