using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers;
using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;

namespace TP_CS_ZORK.CONSOLE.utils
{
    static class GameInstance
    {

        private static Monster _fightingMonster;
        private static Player _playerInstance;

        private static readonly PlayersAccessLayer playersAccessLayer = PlayersAccessLayer.GetInstance();

        // Get a player instance. If none created yet, create one. Else, get the last player data from db, and return it.
        public static async Task<Player> GetPlayerInstance()
        {
            if (_playerInstance == null)
            {
                Console.WriteLine("Enter your name!");
                Console.WriteLine("\n");

                var player = new Player
                {
                    Name = Console.ReadLine(),
                    MaxHp = 100,
                    Hp = 100,
                    Exp = 0
                };

                await playersAccessLayer.AddAsync(player);
                var insertedPlayer = playersAccessLayer.GetSingleWithRelations(p => p.Name == player.Name, true);
                _playerInstance = insertedPlayer;
                //weapons.Add(new Punch());
            } else
            {
                var player = playersAccessLayer.GetSingleWithRelations(p => p.Id == _playerInstance.Id, true);
                _playerInstance = player;
            }

            return _playerInstance;
        }

        // Set the player instance for the first time, if the player exist in database.
        // Pass by the GetPlayerInstance if want to create a new player.
        public static void SetPlayerInstance(int playerId)
        {
            var player = playersAccessLayer.GetSingleWithRelations(p => p.Id == playerId, true);
            _playerInstance = player;
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

        static public Monster SummonMonster(string type)
        {
            _fightingMonster = new Monster();
            switch (type)
            {
                case "Vilain":
                    _fightingMonster.Name = "Vilain";
                    _fightingMonster.Hp = 100;
                    _fightingMonster.Damage = 5;
                    _fightingMonster.MissRate = 20;
                    break;
                case "Grand mechant":
                    _fightingMonster.Name = "Grand mechant";
                    _fightingMonster.Hp = 300;
                    _fightingMonster.Damage = _fightingMonster.Hp / 8;
                    _fightingMonster.MissRate = 10;
                    break;
            }

            return _fightingMonster;
        }

        static public async void Fight(Monster monster, Player player)
        {

            monsterTurn(monster, player);
            // Fight until death
            while (player.Hp > 0 && monster.Hp > 0)
            {
                Menu menu = new Menu(
                CommandsEnum.CmdHit.ToString(),
                CommandsEnum.CmdUseObject.ToString(),
                CommandsEnum.CmdEscape.ToString());

                await menu.Activate();
                if (monster.Hp > 0)
                {
                    monsterTurn(monster, player);
                }
                
            }
            // Player is dead
            if (player.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n");
                Console.WriteLine($"You just died!");
                player.Hp = 100;
                Console.ReadLine();

                var menu = new Menu(
                    CommandsEnum.CmdCreateNewGame.ToString(),
                    CommandsEnum.CmdLoadSavedGame.ToString(),
                    CommandsEnum.CmdAbout.ToString(),
                    CommandsEnum.CmdExit.ToString()
                );
                await menu.Activate();
            }

        }

        private static void monsterTurn(Monster monster, Player player)
        {
            if(monster.Name == "Grand mechant")
            {
                monster.Damage = monster.Hp / 15;
            }

            Random random = new Random();

            if (random.Next(0,100) < monster.MissRate)
            {
                Console.WriteLine($"A monster attacked you but missed his punch !");
            } else
            {
                Console.WriteLine($"{monster.Name} attacked you !");
                player.Hp -= monster.Damage;
                Console.WriteLine($"You take {monster.Damage}, you still have {player.Hp} lifes left!");
            }
            
            Console.ReadLine();
        }

        public static Monster GetFightingMonster()
        {
            if (_fightingMonster.Hp > 0)
            {
                return _fightingMonster;
            } else
            {
                Monster noMonster = new Monster();
                noMonster.Name = "No monster";
                noMonster.Hp = 0;
                return noMonster;
            }
            
        } 
    }
}
