using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.utils
{
    static class GameInstance
    {

        private static Player _playerInstance;

        public static Player GetPlayerInstance()
        {
            if (_playerInstance == null)
            {
                Console.WriteLine("Enter your name!");
                Console.WriteLine("\n");

                _playerInstance = new Player
                {
                    Name = Console.ReadLine(),
                    MaxHp = 100,
                    Hp = 100,
                    Exp = 0
                };

                //weapons.Add(new Punch());
            }
            return _playerInstance;
        }

        public static Cell GetNextCell(string direction)
        {

            Cell[] map = (Cell[])_playerInstance.Cells;

            switch (direction){
                case "est":
                    int futurePosition = _playerInstance.CurrentCell.PosX + 1;
                    return map.Single(c => c.PosX == futurePosition && c.PosY == _playerInstance.CurrentCell.PosY);

                case "west":
                    return map.Single(c => c.PosX == _playerInstance.CurrentCell.PosX - 1 && c.PosY == _playerInstance.CurrentCell.PosY);

                case "north":
                    return map.Single(c => c.PosY == _playerInstance.CurrentCell.PosY + 1 && c.PosX == _playerInstance.CurrentCell.PosX);

                case "south":
                    return map.Single(c => c.PosY == _playerInstance.CurrentCell.PosY - 1 && c.PosX == _playerInstance.CurrentCell.PosX);
            }

            Console.WriteLine("ERROR : NO CELL FOUND");
            return new Cell();
        }
    }
}
