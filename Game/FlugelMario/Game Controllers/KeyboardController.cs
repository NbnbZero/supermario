using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;

namespace SuperMario.Game_Controllers
{
    class KeyboardControls : Controller
    {
        private Dictionary<Keys, Action<InputState>> controllerMappings;
        private Keys[] previousKeys;
        
        public KeyboardControls(MarioState state, Game1 game) : base (state, game)
        {
            Game = game;
            controllerMappings = new Dictionary<Keys, Action<InputState>>();
            RegisterCommand();
            previousKeys = new Keys[0];
        }

        public void RegisterCommand()
        {
            controllerMappings.Add(Keys.Q, HandleQuit);
            controllerMappings.Add(Keys.P , HandlePauseOrResume);
            controllerMappings.Add(Keys.R, HandlePauseOrResume);
            controllerMappings.Add(Keys.Left, HandleLeft);
            controllerMappings.Add(Keys.Right, HandleRight);
            controllerMappings.Add(Keys.Up, HandleAscend);
            controllerMappings.Add(Keys.Down,HandleDown);
            controllerMappings.Add(Keys.Y, MakeSmall);
            controllerMappings.Add(Keys.U, MakeBig);
            controllerMappings.Add(Keys.I, MakeFire);
            controllerMappings.Add(Keys.O, MakeDead);
            controllerMappings.Add(Keys.B, BumpUp);
            controllerMappings.Add(Keys.X, ChangeToUsed);            
            controllerMappings.Add(Keys.Z, HandleJump);
            //controllerMappings.Add(Keys )
        }

        public void Update()
        {
            if (!Game.Paused)
            {
                Keys[] keysPressed = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in keysPressed.Except(previousKeys))
                {
                    if (controllerMappings.ContainsKey(key))
                    {
                        controllerMappings[key](State);
                    }
                }

                previousKeys = keysPressed;

            } else
            {
                if (Keyboard.GetState().GetPressedKeys().Contains(Keys.R))
                {
                    HandlePauseOrResume(State);
                }
            }
        }
    }
}
