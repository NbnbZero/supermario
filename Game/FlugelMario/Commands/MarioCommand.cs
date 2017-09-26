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
    class MarioCommand : ICommand
    {
        public void Execute(Input state, IMarioState marioState)
        {
            switch (state)
            {
                case Input.Crouch:
                    marioState.Crouch();
                    break;
                case Input.Jump:
                    marioState.Jump();
                    break;
                case Input.RunLeft:
                    marioState.RunLeft();
                    break;
                case Input.IdleLeft:
                    marioState.BeIdle(Input.IdleLeft);
                    break;
                case Input.IdleRight:
                    marioState.BeIdle(Input.IdleRight);
                    break;
                case Input.RunRight:
                    marioState.RunRight();
                    break;
                case Input.MakeSmall:
                    marioState.ChangeSizeToSmall();
                    break;
                case Input.MakeBig:
                    marioState.ChangeSizeToBig();
                    break;
                case Input.MakeFire:
                    marioState.ChangeFireMode();
                    break;
                case Input.MakeDead:
                    marioState.Terminated();
                    break;
                default:
                    marioState.BeIdle();
                    break;
            }
        }
    }
}
