using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Game_Controllers
{
    class KeyboardController_GameControl: ICommandHandler
    {
        public Game1 Game;
        private Dictionary<Keys, ICommand> controllerMappings;
        public KeyboardController_GameControl(Game1 game)
        {
            Game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand();
        }

        public void RegisterCommand()
        {
            controllerMappings.Add(Keys.Q, new QuitGameCommand(Game));
            controllerMappings.Add(Keys.P , new PauseGame(Game));
            controllerMappings.Add(Keys.R, new ResumeGame(Game));
        }

        public void Update()
        {
            Keys[] keysPressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in keysPressed)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }            

        }
    }
}
