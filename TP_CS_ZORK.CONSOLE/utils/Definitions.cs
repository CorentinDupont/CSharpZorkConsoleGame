using System;
using System.Collections.Generic;
using System.Text;

namespace TP_CS_ZORK.CONSOLE.utils
{
    enum CellsEnum
    {
        SPAWN,
        WALL,
        RIVER,
        GRAVEYARD,
        VOLCANO
    }
    public enum CommandsEnum
    {
        CmdAbout,
        CmdCreateNewGame,
        CmdLoadSavedGame,
        CmdExit,
        CmdInventory,
        CmdStats,
        CmdMove
    }
}
