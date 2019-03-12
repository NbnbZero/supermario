using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using Microsoft.Xna.Framework;
using SuperMario.Sound;
using SuperMario.DisplayPanel;

namespace SuperMario.Commands.ControllerCommand
{
    class MarioJumpCommand : ICommand
    {
        private IMario mario;
        public MarioJumpCommand(IMario Mario)
        {
            mario = Mario;
        }

        public void Execute()
        {
            if (!mario.IsInWater)
            {
                mario.State.JumpOrStand();
            }
            else
            {
                if (mario.Velocity.Y <= -mario.maxYSpeed)
                {
                    mario.Swimable = false;
                }
                else if (mario.Swimable)
                {
                    mario.State.Swim();
                }
                          
            }
            
        }
    }
}
