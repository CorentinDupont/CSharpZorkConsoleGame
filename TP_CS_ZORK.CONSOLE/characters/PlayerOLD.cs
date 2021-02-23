//using System;
//using System.Collections.Generic;
//using System.Text;
//using TP_CS_ZORK.CONSOLE.maps;
//using TP_CS_ZORK.CONSOLE.weapons;

//namespace TP_CS_ZORK.CONSOLE.characters
//{
//    class PlayerOLD
//    {
//        private Player(){}
//        private static Player _instance;
//        private static List<Weapon> weapons;
//        //private static List<Items> items;

//        public static Player GetInstance()
//        {
//            if (_instance == null)
//            {
//                _instance = new Player();
//                //weapons.Add(new Punch());
//            }
//            return _instance;
//        }


//        public string name;
//        public int hp = 100;
//        public int maxHP = 100;

//        public int currentCellId;
//        public CellOLD[,] currentMap;

//        public Cell GetCurrentCell(int id)
//        {
//            foreach (Cell cell in currentMap){
//                if (id == cell.id)
//                {
//                    return cell;
//                }
//            }

//            Console.WriteLine("No cell for this player");

//            Cell noCell = new Cell(0, 0, 0);
//            noCell.description = "NO CELL FOR THIS PLAYER";
//            return noCell;
//        }

//        public List<Weapon> GetWeapons()
//        {
//            return weapons;
//        }
//    }
//}
