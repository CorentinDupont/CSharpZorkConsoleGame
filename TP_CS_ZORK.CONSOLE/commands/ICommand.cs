using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    interface ICommand : IBaseCommand
    {
        public void Execute(int number);
    }
}
