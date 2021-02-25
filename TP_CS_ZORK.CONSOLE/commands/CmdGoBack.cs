using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CS_ZORK.CONSOLE.commands
{
    class CmdGoBack : ICommandAsync
    {
        public string Description => "Retour";

        private Menu PreviousMenu { get; set; }

        public CmdGoBack(Menu previousMenu)
        {
            this.PreviousMenu = previousMenu;
        }

        public async Task ExecuteAsync(int number)
        {
            await this.PreviousMenu.Activate();
        }
    }
}
