using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.characters;
using TP_CS_ZORK.CONSOLE.maps;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdCreateNewGame : ICommand
    {
        public string Description => "Create new game";

        public void Execute(int number)
        {
            CreatePlayer();
            CreateMap();
        }

        private void CreatePlayer()
        
            // CREATE PLAYER
            Player player = new Player();

            Console.WriteLine("Enter your name!");
            Console.WriteLine("\n");
            player.name = Console.ReadLine();

            Console.WriteLine($"Welcome to a new world {player.name} !");
            Console.WriteLine("\n\n\n");
        }

        private void CreateMap()
        {
            Random random = new Random();
            int widthMap = random.Next(5, 21);  // creates a number between 5 and 20
            int heightMap = random.Next(5, 21);

            //Console.WriteLine(widthMap);
            //Console.WriteLine(heightMap);

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
        }
    }
}
