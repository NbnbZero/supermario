using SuperMario.Enums;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace SuperMario
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

        public override InputState Update(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up) && !previousKeyboardState.IsKeyDown(Keys.Up))
            {
                HandleUp();
            }
            else if (keyboard.IsKeyDown(Keys.Down) && !previousKeyboardState.IsKeyDown(Keys.Down))
            {
                HandleDown();
            }
            else if (keyboard.IsKeyDown(Keys.Left) && !previousKeyboardState.IsKeyDown(Keys.Left))
            {
                HandleLeft();
            }
            else if (keyboard.IsKeyDown(Keys.Right) && !previousKeyboardState.IsKeyDown(Keys.Right))
            {
                HandleRight();
            }
            else if (keyboard.IsKeyDown(Keys.Y) && !previousKeyboardState.IsKeyDown(Keys.Y))
            {
                state = InputState.MakeSmall;
            }
            else if (keyboard.IsKeyDown(Keys.I) && !previousKeyboardState.IsKeyDown(Keys.I))
            {
                state = InputState.MakeFire;
            }
            else if (keyboard.IsKeyDown(Keys.U) && !previousKeyboardState.IsKeyDown(Keys.U))
            {
                state = InputState.MakeBig;
            }
            else if (keyboard.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
            {
                state = InputState.MakeDead;
            }
            else if (keyboard.IsKeyDown(Keys.X))
            {
                state = InputState.ChangeToUsed;
            }
            else if (keyboard.IsKeyDown(Keys.B))
            {
                state = InputState.BumpUp;
            }
            else if (keyboard.IsKeyDown(Keys.X))
            {
                state = InputState.ChangeToVisible;
            }

            previousKeyboardState = keyboard;

            return state;
        }
    }
}
