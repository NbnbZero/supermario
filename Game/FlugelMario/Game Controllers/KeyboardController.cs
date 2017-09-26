using FlugelMario.Enums;
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
            else if (currentKeyboardState.IsKeyDown(Keys.Y) && !previousKeyboardState.IsKeyDown(Keys.Y))
            {
                state = InputState.MakeSmall;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.I) && !previousKeyboardState.IsKeyDown(Keys.I))
            {
                state = InputState.MakeFire;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.U) && !previousKeyboardState.IsKeyDown(Keys.U))
            {
                state = InputState.MakeBig;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
            {
                state = InputState.MakeDead;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.X) && !previousKeyboardState.IsKeyDown(Keys.X))
            {
                state = InputState.ChangeToUsed;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.B))
            {
                if (Game1.MarioShape == Shape.Big || Game1.MarioShape == Shape.Fire)
                {
                    state = InputState.BreakBrick;
                }
                else
                {
                    state = InputState.BumpUp;
                }
                
            }
            else if (currentKeyboardState.IsKeyDown(Keys.H) && !previousKeyboardState.IsKeyDown(Keys.H) && !previousKeyboardState.IsKeyDown(Keys.H))
            {
                state = InputState.ChangeToVisable;
            }

            previousKeyboardState = currentKeyboardState;

            return state;
        }
    }
}
