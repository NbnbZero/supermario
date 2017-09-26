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
        protected Input state;
        protected IMarioState marioState;

        public Controller(IMarioState state)
        {
            marioState = state;
        }

        public virtual Input Update(KeyboardState keyboard)
        {
            return Input.Nothing;
        }

        public virtual Input Update(GamePadState keyboard)
        {
            return Input.Nothing;
        }

        #region Direction Logic

        protected void HandleUp()
        {
            if (state == Input.Crouch)
            {
                state = Input.Nothing;
            }
            else
            {
                state = Input.Jump;
            }
        }

        protected void HandleDown()
        {
            if (state == Input.Jump)
            {
                state = Input.Nothing;
            }
            else if (marioState.MarioShape == Enums.Shape.Big)
            {
                state = Input.Crouch;
            }
        }

        protected void HandleLeft()
        {
            if (state == Input.RunRight)
            {
                state = Input.IdleRight;
            }
            else if (state == Input.IdleRight)
            {
                state = Input.IdleLeft;
            }
            else
            {
                state = Input.RunLeft;
            }
        }

        protected void HandleRight()
        {
            if (state == Input.RunLeft)
            {
                state = Input.IdleLeft;
            }
            else if (state == Input.IdleLeft)
            {
                state = Input.IdleRight;
            }
            else
            {
                state = Input.RunRight;
            }
        }
        #endregion
    }
}
