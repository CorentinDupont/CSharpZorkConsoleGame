using System;
using TP_CS_ZORK.CONSOLE.commands;


namespace TP_CS_ZORK.CONSOLE.commandsMenu
{
    class MainMenu
    {

        public void display()
        {
            ICommand[] commands = new ICommand[]
            {
                new CmdCreateNewGame(),
                new CmdLoadSavedGame(),
                new CmdAbout(),
                new CmdExit()
            };

            Console.WriteLine("\n\n\n");


            // This loop creates a list of commands:
            displayCommands(commands);

            // Read until the input is valid.
            var userChoice = string.Empty;
            var commandIndex = -1;

            while (!int.TryParse(userChoice, out commandIndex) || commandIndex > commands.Length || userChoice == "0")
            {
                Console.Clear();
                Console.WriteLine($"Select number between 0 and {commands.Length} \n");
                displayCommands(commands);
                userChoice = Console.ReadLine();
            }

            commands[commandIndex - 1].Execute(commandIndex);

            Console.WriteLine("\n\n\n");
        }

        public static void displayCommands(ICommand[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, commands[i].Description);
            }
            Console.WriteLine("\n");

        }

    }

    
    
}
