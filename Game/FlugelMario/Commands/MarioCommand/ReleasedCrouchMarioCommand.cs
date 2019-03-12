using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands.ControllerCommand
{
    class ReleasedCrouchMarioCommand : ICommand
    {
        private IMario mario;
        public ReleasedCrouchMarioCommand(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            if((mario.State.MarioShape==Shape.Small|| 
                mario.State.MarioShape ==Shape.StarSmall)&&
                mario.State.MarioPosture == Posture.Crouch)
            {
                mario.State.MarioPosture = Posture.Stand;
                return;
            }

            if (mario.State.MarioPosture == Posture.Crouch)
            {
                mario.State.JumpOrStand();
            }
        }

    }
}
