using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using FlugelMario.Interfaces;

namespace FlugelMario
{
    public class GamePadController_GameControl : Controller
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        Game1 Game;
        GamePadState currentGamepadState;

        public GamePadController_GameControl(Game1 game)
        {
            Game = game;
            controllerMappings = new Dictionary<Buttons, ICommand>();
            RegisterCommand();
        }
        public void RegisterCommand()
        {
            controllerMappings.Add(Buttons.Start, new PauseGame(Game));
        }
        public void Update()
        {
            currentGamepadState = GamePad.GetState(PlayerIndex.One);
            if (currentGamepadState.Buttons.Start == ButtonState.Pressed)
            {
                controllerMappings[Buttons.Start].Execute();
            }
        }
    }
}
