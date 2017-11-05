using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using TileDefinition;
namespace SuperMario.Commands.ControllerCommand
{
    class MarioAccelerateCommand:ICommand
    {
        private int maxFireballNum = 3;
        private float fireBallVelocityX = 4.5f;

        private IMario mario;

        public MarioAccelerateCommand(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.IsInAir && mario.State.MarioPosture == Posture.Running)
            {
                mario.maxSpeed = GameUtility.MarioSprintSpeed;
            }

            if(mario.State.MarioShape==Shape.Fire||
                mario.State.MarioShape==Shape.StarBig&&
                mario.PreStarShape == Shape.Fire)
            {

            }
        }
    }

   
}
