using System;
using System.Collections.Generic;
using System.Text;
using TP_CS_ZORK.CONSOLE.maps;

namespace TP_CS_ZORK.CONSOLE.characters
{
    class Monster
    {
        public Monster(int p_currentCellId) {
            currentCellId = p_currentCellId;
        }

        public string name = "Vilain";
        public int hp = 100;
        public int damages = 5;
        public int currentCellId;

        //public Cell GetCurrentCell(int id)
        //{
        //    foreach (Cell cell in currentMap){
        //        if (id == cell.id)
        //        {
        //            return cell;
        //        }
        //    }

        //    Console.WriteLine("No cell for this player");

        //    Cell noCell = new Cell(0, 0, 0);
        //    noCell.description = "NO CELL FOR THIS PLAYER";
        //    return noCell;
        //}
    }
}
