using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.maps;
using TP_CS_ZORK.CONSOLE.utils;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdCreateNewGame : ICommandAsync
    {
        public string Description => "Create new game";

        private readonly PlayersAccessLayer playersAccessLayer = PlayersAccessLayer.GetInstance();

        public async Task ExecuteAsync(int number)
        {

            // Setting game
            Player player = await CreatePlayer();
            CellOLD[,] map = CreateMap();
            DescribeMap(map, player);

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
        
            // CREATE PLAYER
            var player = new Player();

            Console.WriteLine("Enter your name!");
            Console.WriteLine("\n");

            player.Name = Console.ReadLine();
            player.MaxHp = 20;
            player.Hp = player.MaxHp;
            player.Exp = 0;

            await playersAccessLayer.AddAsync(player);

            Console.WriteLine($"Welcome to a new world {player.Name} !");
            Console.WriteLine("\n\n\n");

            var insertedPlayer = playersAccessLayer.GetSingle(p => p.Name == player.Name, true);
            return insertedPlayer;
        }

        private CellOLD[,] CreateMap()
        {
            Random random = new Random();
            int widthMap = random.Next(5, 21);  // creates a number between 5 and 20
            int heightMap = random.Next(5, 21);

            CellOLD[,] map = new CellOLD[widthMap, heightMap];

            // fill each row
            for (int i = 0; i < widthMap; i++)
            {
                // fill each column
                for (int y = 0; y < heightMap; y++)
                {
                    //Console.WriteLine($"i : {i}");
                    //Console.WriteLine($"y : {y}");

                    map.SetValue(new CellOLD(i, y), i, y);
                }
            }

            //Console.WriteLine($"Total cells : {map.Length});

            return map;
        }

        private void SpawnPlayer(Player player, CellOLD[,] map)
        {

            int widthMap = (int)map.GetLongLength(0); // Get width map
            int heightMap = (int)map.GetLongLength(1); // Get height map
            Console.WriteLine($"widthMap : {widthMap}");
            Console.WriteLine($"heightMap : {heightMap}");


            Random random = new Random();
            int randomPositionOnWidthAxis = random.Next(5, widthMap);
            int randomPositionOnHeightAxis = random.Next(5, heightMap);

            // Create a cell for the player to spawn, and replace the one that is empty
            CellOLD currentCellPlayer = (CellOLD) map.GetValue(randomPositionOnWidthAxis, randomPositionOnHeightAxis);
            currentCellPlayer.description = CellsEnum.SPAWN.ToString();
            currentCellPlayer.posX = randomPositionOnWidthAxis;
            currentCellPlayer.posY = randomPositionOnHeightAxis;

            map.SetValue(currentCellPlayer, randomPositionOnWidthAxis, randomPositionOnHeightAxis);
            // player.currentCellId = currentCellPlayer.id;

        }

        /*
         * Create all details on map : spawns, obstacles, monsters...
         */
        public void DescribeMap(CellOLD[,] map, Player player)
        {
            SpawnPlayer(player, map);
        }
    }
}
