using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using FlugelMario.Interfaces;

namespace FlugelMario
{
    public class GamePadController : Controller
    {
        private GamePadState previousGamepadState;

        public GamePadController(GamePadState gamepad, IMarioState marioState) : base (marioState)
        {
            previousGamepadState = gamepad;
        }

        #region Interface Implementation

        public override InputState Update(GamePadState currentGamepadState)
        {
            if (currentGamepadState.IsButtonDown(Buttons.DPadUp) && !previousGamepadState.IsButtonDown(Buttons.DPadUp))
            {
                HandleUp();
            }
            else if (currentGamepadState.IsButtonDown(Buttons.DPadDown) && !previousGamepadState.IsButtonDown(Buttons.DPadDown))
            {
                HandleDown();
            }
            else if (currentGamepadState.IsButtonDown(Buttons.DPadLeft) && !previousGamepadState.IsButtonDown(Buttons.DPadLeft))
            {
                HandleLeft();
            }
            else if (currentGamepadState.IsButtonDown(Buttons.DPadRight) && !previousGamepadState.IsButtonDown(Buttons.DPadRight))
            {
                HandleRight();
            }

            previousGamepadState = currentGamepadState;

            return state;
        }

        #endregion
    }
}
