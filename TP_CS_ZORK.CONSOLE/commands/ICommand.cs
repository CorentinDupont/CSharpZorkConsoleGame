using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    interface ICommand : IBaseCommand
    {
        void Execute(int number);

    }
}
