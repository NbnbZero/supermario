using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class GamepadController : Controller
    {
        private GamePadState previousGamePadState;

        public GamepadController(GamePadState gamepad, IMarioState marioState) : base (marioState)
        {
            previousGamePadState = gamepad;
        }

        #region Interface Implementation

        public override InputState Update(GamePadState gamepad)
        {
            if (gamepad.IsButtonDown(Buttons.DPadUp) && !previousGamePadState.IsButtonDown(Buttons.DPadUp))
            {
                HandleUp();
            }
            else if (gamepad.IsButtonDown(Buttons.DPadDown) && !previousGamePadState.IsButtonDown(Buttons.DPadDown))
            {
                HandleDown();
            }
            else if (gamepad.IsButtonDown(Buttons.DPadLeft) && !previousGamePadState.IsButtonDown(Buttons.DPadLeft))
            {
                HandleLeft();
            }
            else if (gamepad.IsButtonDown(Buttons.DPadRight) && !previousGamePadState.IsButtonDown(Buttons.DPadRight))
            {
                HandleRight();
            }

            previousGamePadState = gamepad;

            return state;
        }

        #endregion
    }
}
