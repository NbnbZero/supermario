using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using FlugelMario.AbstractClasses;

namespace FlugelMario
{
    public abstract class Controller
    {
        protected InputState state;
        protected IMarioState marioState;

        public Controller(IMarioState state)
        {
            marioState = state;
        }

        public virtual InputState Update(KeyboardState keyboard)
        {
            return InputState.Nothing;
        }

        public virtual InputState Update(GamePadState keyboard)
        {
            return InputState.Nothing;
        }

        #region Direction Logic

        protected void HandleUp()
        {
            if (state == InputState.Crouch)
            {
                state = InputState.Nothing;
            }
            else
            {
                state = InputState.Jump;
            }
        }

        protected void HandleDown()
        {
            if (state == InputState.Jump)
            {
                state = InputState.Nothing;
            }
            else if (marioState.MarioShape == Enums.Shape.Big || marioState.MarioShape == Enums.Shape.Fire)
            {
                state = InputState.Crouch;
            }
        }

        protected void HandleLeft()
        {
            if (state == InputState.RunRight)
            {
                state = InputState.IdleRight;
            }
            else if (state == InputState.IdleRight)
            {
                state = InputState.IdleLeft;
            }
            else
            {
                state = InputState.RunLeft;
            }
        }

        protected void HandleRight()
        {
            if (state == InputState.RunLeft)
            {
                state = InputState.IdleLeft;
            }
            else if (state == InputState.IdleLeft)
            {
                state = InputState.IdleRight;
            }
            else
            {
                state = InputState.RunRight;
            }
        }
        #endregion
    }
}
