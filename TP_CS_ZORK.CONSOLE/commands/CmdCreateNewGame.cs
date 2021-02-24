using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;
using System.Collections;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdCreateNewGame : ICommandAsync
    {

        const int minWidthMap = 3;
        const int minHeightMap = 3;
        const int maxWidthMap = 3;
        const int maxHeightMap = 3;
        int widthMap = 0;
        int heightMap = 0;

        public new string Description => "Create new game";

        private readonly PlayersAccessLayer playersAccessLayer = PlayersAccessLayer.GetInstance();
        private readonly CellsAccessLayer cellsAccessLayer = CellsAccessLayer.GetInstance();
        private readonly WeaponsAccessLayer weaponsAccessLayer = WeaponsAccessLayer.GetInstance();
        private readonly WeaponsTypeAccessLayer weaponsTypeAccessLayer = WeaponsTypeAccessLayer.GetInstance();

        public async Task ExecuteAsync(int number)
        {

            // Setting game
            Player player = await CreatePlayer();
            await CreateWeapon(player);
            Cell[] map = await CreateMap(player);
            await SpawnPlayer(player, map);

            // Display game
            var menu = new Menu(
                CommandsEnum.CmdInventory.ToString(),
                CommandsEnum.CmdStats.ToString(),
                CommandsEnum.CmdMove.ToString(),
                CommandsEnum.CmdExit.ToString());

            await menu.Activate();
        }


        // Create the player with a custom pseudo and base stats in DB
        private async Task<Player> CreatePlayer() {
            Player player = await GameInstance.GetPlayerInstance();

            Console.WriteLine($"Welcome to a new world {player.Name} !");
            Console.WriteLine("\n\n\n");

            //var insertedPlayer = playersAccessLayer.GetSingle(p => p.Name == player.Name, true);
            //return insertedPlayer;
            return player;

        }

        // Create a weapon for the player
        private async Task CreateWeapon(Player player)
        {
            WeaponsType simpleWeapon = new WeaponsType();
            simpleWeapon.Name = "Punch";
            simpleWeapon.Damage = 30;
            simpleWeapon.MissRate = 10;
            var insertedWeaponTypeId = await weaponsTypeAccessLayer.AddAsync(simpleWeapon);

            Weapon weapon = new Weapon();
            weapon.WeaponTypeId = insertedWeaponTypeId;
            weapon.PlayerId = player.Id;
            await weaponsAccessLayer.AddAsync(weapon);
        }

        private async Task<Cell[]> CreateMap(Player player)
        {
            Random random = new Random();
            widthMap = random.Next(minWidthMap, maxWidthMap + 1);  // creates a number between 5 and maxWidthMap
            heightMap = random.Next(minHeightMap, maxHeightMap + 1);

            Cell[] map = new Cell[widthMap * heightMap];

            //int idNewCell = 0;
            int rateCellIsWalkable = 0;
            int indexArray = 0;
            // fill each row
            for (int i = 0; i < widthMap; i++)
            {
                // fill each column
                for (int y = 0; y < heightMap; y++)
                {
                    //idNewCell++;
                    Cell newCell = new Cell();
                    //newCell.Id = indexArray + 1;
                    newCell.PosX = i;
                    newCell.PosY = y;
                    newCell.MonsterRate = 25;
                    if (random.Next(0, 101) > rateCellIsWalkable) // Determine if the cell is walkable
                    {
                        newCell.CanMoveTo = true;
                        newCell.Description = CellsEnum.DIRT_ROAD.ToString();
                    } else
                    {
                        newCell.CanMoveTo = false;
                        newCell.Description = CellsEnum.WALL.ToString();
                    }

                    newCell.PlayerId = player.Id;

                    //await cellsAccessLayer.AddAsync(newCell);
                    map[indexArray] = newCell; // Set the cell in the map
                    indexArray++;

                }
            }

            List<Cell> cellList = new List<Cell>(map);

            //List<Cell> cellList = new List<Cell>(map);
            //List<Task> tasks = new List<Task>();
            //cellList.ForEach(cell =>
            //{
            //    cell.PlayerId = player.Id;
            //    tasks.Add(cellsAccessLayer.AddAsync(cell));
            //});

            // Task.WaitAll(tasks.ToArray());

            await cellsAccessLayer.AddManyAsync(map);

            //cellList.ForEach(async cell =>
            //{
            //    cell.PlayerId = player.Id;
            //    await cellsAccessLayer.AddAsync(cell);
            //});


            var insertedMap = cellsAccessLayer.GetCollection(c => c.PlayerId == player.Id);
            return insertedMap.ToArray();
        }

        // Set the current cell id of the player randomly
        private async Task SpawnPlayer(Player player, Cell[] map)
        {

            Cell lastCell = map.Last();
            int widthMap = lastCell.PosX ; // Get width map
            int heightMap = lastCell.PosY; // Get height map


            Random random = new Random();
            int randomPositionOnWidthAxis = random.Next(0, widthMap - 1);
            int randomPositionOnHeightAxis = random.Next(0, heightMap - 1);

            // Create a cell for the player to spawn
            Cell newCellPlayer = map.Single(c => c.PosX == randomPositionOnWidthAxis && c.PosY == randomPositionOnHeightAxis);

            // Ensure that the cell is not a wall
            newCellPlayer.Description = CellsEnum.SPAWN.ToString();
            newCellPlayer.CanMoveTo = true;

            await cellsAccessLayer.UpdateAsync(newCellPlayer);

            player.CurrentCellId = newCellPlayer.Id;
            await playersAccessLayer.UpdateAsync(player);
        }
    }
}
