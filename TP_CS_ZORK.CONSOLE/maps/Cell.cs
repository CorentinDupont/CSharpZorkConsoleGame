

namespace TP_CS_ZORK.CONSOLE.maps
{
    class Cell
    {
        public Cell(int p_posX, int p_posY)
        {
            posX = p_posX;
            posY = p_posY;
        }

        string description;
        int posX;
        int posY;
        int monsterRate;
        int itemRate;
        bool canMoveTo;
        int playerId;
    }
}
