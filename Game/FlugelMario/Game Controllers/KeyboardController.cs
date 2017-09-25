using FlugelMario.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace FlugelMario
{
    public class KeyboardController : Controller
    {
        private KeyboardState previousKeyboardState;

        public KeyboardController (KeyboardState keyboard, IMarioState marioState)
            : base (marioState)
        {
            previousKeyboardState = keyboard;
            state = InputState.Nothing;
        }

        public override InputState Update(KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Up) && !previousKeyboardState.IsKeyDown(Keys.Up))
            {
                HandleUp();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Down) && !previousKeyboardState.IsKeyDown(Keys.Down))
            {
                HandleDown();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Left) && !previousKeyboardState.IsKeyDown(Keys.Left))
            {
                HandleLeft();
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Right) && !previousKeyboardState.IsKeyDown(Keys.Right))
            {
                HandleRight();
            }
            else
            {
                changeShape(currentKeyboardState);
            }

            previousKeyboardState = currentKeyboardState;

            return state;
        }
    }
}
