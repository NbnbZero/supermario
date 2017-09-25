using Microsoft.Xna.Framework.Input;

namespace FlugelMario
{
    public class KeyboardController : IController
    {
        private KeyboardState previousKeyboardState;

        public KeyboardController (KeyboardState keyboard)
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

            previousKeyboardState = currentKeyboardState;

            return state;
        }
    }
}
