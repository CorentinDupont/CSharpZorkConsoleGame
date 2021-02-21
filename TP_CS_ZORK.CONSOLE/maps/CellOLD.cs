

using TP_CS_ZORK.CONSOLE.characters;

namespace TP_CS_ZORK.CONSOLE.maps
{
    class CellOLD
    {
        public CellOLD(int p_posX, int p_posY, string p_description, int p_playerId)
        {
            posX = p_posX;
            posY = p_posY;
            description = p_description;
            playerId = p_playerId;
        }

        public CellOLD(int p_posX, int p_posY)
        {
            posX = p_posX; 
            posY = p_posY;
            id = p_id;
            monsterRate = 30;
            itemRate = 10;
    }

    public int id;
        public string description;
        public int posX;
        public int posY;
        public int monsterRate;
        public int itemRate;
        public bool canMoveTo;
        public int playerId;
        public Monster currentMonster;
    }
}
