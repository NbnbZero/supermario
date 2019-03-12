using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.DisplayPanel;

namespace SuperMario.Commands.ControllerCommand
{
    class MarioCrouchCommand : ICommand
    {
        private IMario mario;

        public MarioCrouchCommand(IMario Mario)
        {
            mario = Mario;
        }

        public void Execute()
        {
            mario.State.Crouch();

            if (mario.State.MarioShape == Shape.Small || mario.State.MarioShape== Shape.StarSmall)             
            {
                mario.State.MarioPosture = Posture.Crouch;
            }
        }

        

    }
}
