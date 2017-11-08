using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands.ControllerCommand
{
    class ReleasedLeftMarioCommand : ICommand
    {
        IMario mario;
        public ReleasedLeftMarioCommand(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            if (mario.State.MarioPosture == Posture.Running)
            {
                mario.State.RunRight();
            }
        }
    }
}
