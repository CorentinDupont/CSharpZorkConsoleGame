using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
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
            int futurePosition;

            switch (direction){
                case "est":
                    futurePosition = _playerInstance.CurrentCell.PosX + 1;
                    return map.Single(c => c.PosX == futurePosition && c.PosY == _playerInstance.CurrentCell.PosY);

                case "west":
                    futurePosition = _playerInstance.CurrentCell.PosX - 1;
                    return map.Single(c => c.PosX == futurePosition && c.PosY == _playerInstance.CurrentCell.PosY);

                case "north":
                    futurePosition = _playerInstance.CurrentCell.PosY + 1;
                    return map.Single(c => c.PosY == futurePosition && c.PosX == _playerInstance.CurrentCell.PosX);

                case "south":
                    futurePosition = _playerInstance.CurrentCell.PosY - 1;
                    return map.Single(c => c.PosY == futurePosition && c.PosX == _playerInstance.CurrentCell.PosX);
            }

            Console.WriteLine("ERROR : NO CELL FOUND");
            return new Cell();
        }

        static public async void Fight(Monster monster, Player player)
        {
            Console.WriteLine($"You are attacked by a {monster.Name} !");
            player.Hp -= monster.Damage;
            Console.WriteLine($"You take {monster.Damage}, you still have {player.Hp} !");
            Console.WriteLine($"What do you want to do ?");

            while (player.Hp != 0 || monster.Hp != 0)
            {
                Menu menu = new Menu(
                CommandsEnum.CmdHit.ToString(),
                CommandsEnum.CmdUseObject.ToString(),
                CommandsEnum.CmdEscape.ToString());

                await menu.Activate();
            }
        }
    }
}
