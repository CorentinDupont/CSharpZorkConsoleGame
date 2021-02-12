namespace TP_CS_ZORK.CONSOLE.commands
{
    interface ICommand
    {
        string Description { get; }

        void Execute(int number);
    }
}
