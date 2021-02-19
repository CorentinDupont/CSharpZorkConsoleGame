

namespace TP_CS_ZORK.CONSOLE.maps
{
    class Cell
    {
        public Cell(int p_posX, int p_posY, string p_description, int p_playerId)
        {
            posX = p_posX;
            posY = p_posY;
            description = p_description;
            playerId = p_playerId;
        }

        public Cell(int p_posX, int p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        public string description;
        public int posX;
        public int posY;
        public int monsterRate;
        public int itemRate;
        public bool canMoveTo;
        public int playerId;
    }
}
