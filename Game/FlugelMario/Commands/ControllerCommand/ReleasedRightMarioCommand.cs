using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario.Commands.ControllerCommand
{
    class ReleasedRightMarioCommand : ICommand
    {
        IMario mario;
        public ReleasedRightMarioCommand(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            if (mario.State.MarioPosture == Posture.Running)
            {
                mario.State.ChangeToLeft();
            }
        }
    }
}
