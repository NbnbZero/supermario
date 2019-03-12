using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands.ControllerCommand
{
    class ReleasedFlashCommand : ICommand
    {
        private IMario mario;
        public ReleasedFlashCommand(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            mario.Flashable = true;
            mario.IsProtected = false;
        }

    }
}
