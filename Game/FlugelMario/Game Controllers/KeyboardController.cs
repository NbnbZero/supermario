using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace FlugelMario
{
    class KeyboardController : IController
    {
        private KeyboardState _keyboard;

        public KeyboardController (KeyboardState keyboard)
        {
            _keyboard = keyboard;
        }

        #region Interface Implementation

        public InputState Update()
        {
            InputState state = InputState.Nothing;

            if (_keyboard.IsKeyDown(Keys.W))
            {
                state = InputState.Jump;
            }
            else if (_keyboard.IsKeyDown(Keys.S))
            {
                state = InputState.Crouch;
            }
            else if (_keyboard.IsKeyDown(Keys.A))
            {
                state = InputState.RunLeft;
            }
            else if (_keyboard.IsKeyDown(Keys.D))
            {
                state = InputState.RunRight;
            }

            return state;
        }

        #endregion
    }
}
