using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;

namespace SuperMario.Game_Controllers
{
    class GamepadControls : Controller
    {
        private Dictionary<Buttons, Action<InputState>> controllerMappings;
        private List<Buttons> previousButton;
        private int _controllerNumber;

        #region Public

        public GamepadControls(MarioState state, Game1 game, int controllerNumber) : base(state, game)
        {
            Game = game;
            controllerMappings = new Dictionary<Buttons, Action<InputState>>();
            RegisterCommand();
            previousButton = new List<Buttons>();
            _controllerNumber = controllerNumber;
        }

        public void RegisterCommand()
        {
            controllerMappings.Add(Buttons.Start, HandlePauseOrResume);
            controllerMappings.Add(Buttons.DPadLeft, HandleLeft);
            controllerMappings.Add(Buttons.DPadRight, HandleRight);
            controllerMappings.Add(Buttons.DPadUp, HandleAscend);
            controllerMappings.Add(Buttons.DPadDown, HandleDown);
            controllerMappings.Add(Buttons.Y, HandleJump);
        }

        public void Update()
        {
            if (!Game.Paused)
            {
                List<Buttons> buttonPressed = GetButtons();

                foreach (Buttons button in buttonPressed.Except(previousButton))
                {
                    if (controllerMappings.ContainsKey(button))
                    {
                        controllerMappings[button](State);
                    }
                }

                previousButton = buttonPressed;

            } else
            {
                if (GamePad.GetState(_controllerNumber).IsButtonDown(Buttons.Start))
                {
                    HandlePauseOrResume(State);
                }
            }
        }

        #endregion 

        #region Private

        private List<Buttons> GetButtons()
        {
            List<Buttons> buttonsPressed = new List<Buttons>();

            GamePadState gamePadState = GamePad.GetState(_controllerNumber);

            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                if (gamePadState.IsButtonDown(button))
                {
                    buttonsPressed.Add(button);
                }
            }

            return buttonsPressed;
        }

        #endregion 
    }
}