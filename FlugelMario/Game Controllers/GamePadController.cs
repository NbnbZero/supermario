using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace FlugelMario
{
    class GamePadController : IController
    {
        private GamePadState _gamepad;

        public GamePadController(GamePadState gamepad)
        {
            _gamepad = gamepad;
        }

        #region Interface Implementation

        public InputState Update()
        {
            InputState state = InputState.Nothing;

            if (_gamepad.IsButtonDown(Buttons.DPadUp))
            {
                state = InputState.Jump;
            }
            else if (_gamepad.IsButtonDown(Buttons.DPadDown))
            {
                state = InputState.Crouch;
            }
            else if (_gamepad.IsButtonDown(Buttons.DPadLeft))
            {
                state = InputState.RunLeft;
            }
            else if (_gamepad.IsButtonDown(Buttons.DPadRight))
            {
                state = InputState.RunRight;
            }

            return state;
        }

        #endregion
    }
}
