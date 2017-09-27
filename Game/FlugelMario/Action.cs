using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.AbstractClasses;

namespace SuperMario
{
    class Action : IAction
    {
        public void Execute(InputState state, IMarioState marioState)
        {
            if (marioState != null)
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
                    case InputState.MakeSmall:
                        marioState.ChangeSizeToSmall();
                        break;
                    case InputState.MakeBig:
                        marioState.ChangeSizeToBig();
                        break;
                    case InputState.MakeFire:
                        marioState.ChangeFireMode();
                        break;
                    case InputState.MakeDead:
                        marioState.Terminated();
                        break;
                    default:
                        marioState.BeIdle();
                        break;
                }
            }
        }
    }
}