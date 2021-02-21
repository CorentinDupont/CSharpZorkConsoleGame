using System;
using TP_CS_ZORK.CONSOLE.commandsMenu;

namespace TP_CS_ZORK.CONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.display();
            new Test();
        }
    }
}
