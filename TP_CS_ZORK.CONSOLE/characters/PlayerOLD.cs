using System;
using System.Collections.Generic;
using System.Text;
using TP_CS_ZORK.CONSOLE.maps;

namespace TP_CS_ZORK.CONSOLE.characters
{
    class PlayerOLD
    {
        private Player(){}
        private static Player _instance;

        public static Player GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }


        public string name;
        public int hp = 100;
        public int currentCellId;
        public CellOLD[] currentMap;
    }
}
