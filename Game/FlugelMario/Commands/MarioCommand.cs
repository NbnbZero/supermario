using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.AbstractClasses;
using SuperMario.Interfaces;
using SuperMario.States.MarioStates;

namespace SuperMario
{
    class MarioCommand : ICommand
    {
        public void Execute(InputState state, IMarioState marioState)
        {
            switch (state)
            {
                case InputState.Crouch:
                    marioState.Crouch();
                    break;
                case InputState.Ascend:
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
        public void Execute()
        {
        }
    }
}
