using System;
using System.Collections.Generic;
using System.Text;
using TP_CS_ZORK.CONSOLE.commands;
using TP_CS_ZORK.CONSOLE.utils;

/*
 * 
 * To create a menu, just make an instance of this class with all the commands you want to display, example :
 *             new Menu(
 *              CommandsEnum.nameCommand.ToString(),
 *              ...);
 *              
 * The command should exists in the enum CommandsEnum in the Definitions.cs file
 *
 */

namespace TP_CS_ZORK.CONSOLE.commands
{
    class Menu
    {
        public Menu(params string[] commandsToCreate)
        {
            List<ICommand> commandsCreated = new List<ICommand>();

            // Loop through all the commands to create
            foreach (string command in commandsToCreate)
            {

                // Loop through all existing commands 
                foreach (Enum existingCommand in Enum.GetValues(typeof(CommandsEnum)))
                {
                    if(command == existingCommand.ToString())
                    {
                        string objectToInstantiate = "TP_CS_ZORK.CONSOLE.commands." + command + ", TP_CS_ZORK.CONSOLE";
                        var objectType = Type.GetType(objectToInstantiate);
                        var instantiatedObject = Activator.CreateInstance(objectType);

                        commandsCreated.Add((ICommand)instantiatedObject);
                        break;
                    }

                }

            }

            Console.WriteLine("\n\n\n");

            // This loop creates a list of commands:
            DisplayCommands(commandsCreated);

            // Read until the input is valid.
            ReadInput(commandsCreated);
        }

        // Execute the command selected by th player
        protected static void ReadInput(List<ICommand> commands)
        {
            var userChoice = string.Empty;
            int commandIndex;
            while (!int.TryParse(userChoice, out commandIndex) || commandIndex > commands.Count || userChoice == "0")
            {
                Console.Clear();
                DisplayCommands(commands);
                userChoice = Console.ReadLine();
            }

            commands[commandIndex - 1].Execute(commandIndex);

            Console.WriteLine("\n\n\n");
        }

        // Display names of list of commands
        protected static void DisplayCommands(List<ICommand> commands)
        {
            Console.WriteLine("\n\n\n");

            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, commands[i].Description);
            }
            Console.WriteLine("\n");

        }
    }
}
