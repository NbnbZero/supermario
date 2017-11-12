using SuperMario.Enums;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Commands
{
    class ChangeDeadState : ICommand
    {
        IMario mario;
        public ChangeDeadState(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            mario.State.Terminated();
        }
    }
}
