using SuperMario.Enums;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    class ChangeSmallState : ICommand
    {
        IMario mario;
        public ChangeSmallState(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            mario.State.ChangeSizeToSmall();
        }
    }
}
