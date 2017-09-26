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
            state = Input.Nothing;
        }

        public override Input Update(KeyboardState currentKeyboardState)
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
            else if (currentKeyboardState.IsKeyDown(Keys.Y) && !previousKeyboardState.IsKeyDown(Keys.Y))
            {
                state = Input.MakeSmall;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.I) && !previousKeyboardState.IsKeyDown(Keys.I))
            {
                state = Input.MakeFire;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.U) && !previousKeyboardState.IsKeyDown(Keys.U))
            {
                state = Input.MakeBig;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
            {
                state = Input.MakeDead;
            }

            previousKeyboardState = currentKeyboardState;

            return state;
        }
    }
}
