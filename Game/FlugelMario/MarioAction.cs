using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.AbstractClasses;

namespace FlugelMario
{
    class Action : IAction
    {
        public void Execute(InputState state, IMarioState marioState)
        {
            switch (state)
            {
                case InputState.Crouch:
                    marioState.Crouch();
                    break;
                case InputState.Jump:
                    marioState.Jump();
                    break;
                case InputState.RunLeft:
                    marioState.RunLeft();
                    break;
                case InputState.IdleLeft:
                    marioState.BeIdle(InputState.IdleLeft);
                    break;
                case InputState.IdleRight:
                    marioState.BeIdle(InputState.IdleRight);
                    break;
                case InputState.RunRight:
                    marioState.RunRight();
                    break;
                default:
                    marioState.BeIdle();
                    break;
            }
        }
    }
}
