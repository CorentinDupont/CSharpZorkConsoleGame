using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.maps;
using TP_CS_ZORK.CONSOLE.utils;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdCreateNewGame : ICommand
    {
        public string Description => "Create new game";

        public void Execute(int number)
        {
            Player player = CreatePlayer();
            Cell[,] map = CreateMap();
            DescribeMap(map, player);


        }

        private Player CreatePlayer() { 
        
            // CREATE PLAYER
            Player player = new Player();

            Console.WriteLine("Enter your name!");
            Console.WriteLine("\n");
            player.name = Console.ReadLine();

            Console.WriteLine($"Welcome to a new world {player.name} !");
            Console.WriteLine("\n\n\n");

            return player;
        }

        private Cell[,] CreateMap()
        {
            Random random = new Random();
            int widthMap = random.Next(5, 21);  // creates a number between 5 and 20
            int heightMap = random.Next(5, 21);

            Cell[,] map = new Cell[widthMap, heightMap];

            // fill each row
            for (int i = 0; i < widthMap; i++)
            {
                // fill each column
                for (int y = 0; y < heightMap; y++)
                {
                    //Console.WriteLine($"i : {i}");
                    //Console.WriteLine($"y : {y}");

                    map.SetValue(new Cell(i, y), i, y);
                }
            }

            //Console.WriteLine($"Total cells : {map.Length});

            return map;
        }

        private void SpawnPlayer(Player player, Cell[,] map)
        {

            int widthMap = (int)map.GetLongLength(0); // Get width map
            int heightMap = (int)map.GetLongLength(1); // Get height map
            Console.WriteLine($"widthMap : {widthMap}");
            Console.WriteLine($"heightMap : {heightMap}");


            Random random = new Random();
            int randomPositionOnWidthAxis = random.Next(5, widthMap + 1);
            int randomPositionOnHeightAxis = random.Next(5, heightMap + 1);

            // Create a cell for the player to spawn, and replace the one that is empty
            Cell currentCellPlayer = (Cell)map.GetValue(randomPositionOnWidthAxis, randomPositionOnHeightAxis);
            currentCellPlayer.description = Definitions.SPAWN.ToString();
            currentCellPlayer.posX = randomPositionOnWidthAxis;
            currentCellPlayer.posY = randomPositionOnHeightAxis;

            map.SetValue(currentCellPlayer, randomPositionOnWidthAxis, randomPositionOnHeightAxis);
            player.currentCellId = currentCellPlayer.id;

        }

        /*
         * Create all details on map : spawns, obstacles, monsters...
         */
        public void DescribeMap(Cell[,] map, Player player)
        {

            SpawnPlayer(player, map);
        }
    }
}
