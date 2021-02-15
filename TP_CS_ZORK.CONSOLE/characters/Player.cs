using System;
using System.Collections.Generic;
using System.Text;
using TP_CS_ZORK.CONSOLE.maps;

namespace TP_CS_ZORK.CONSOLE.characters
{
    class Player
    {
        public string name;
        int hp = 100;
        Cell currentCell;
        Cell[] currentMap;
    }
}
