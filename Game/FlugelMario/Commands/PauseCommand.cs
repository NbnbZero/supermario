using FlugelMario.States.GameState;
using SuperMairo.Interfaces;
using SuperMairo.States.GameState;
using SuperMario;
using SuperMario.Interfaces;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Commands
{
    public class PauseCommand : ICommand
    {
        private Game1 mygame;

        public PauseCommand(Game1 game)
        {
            mygame = game;
        }

        public void Execute()
        {
            if (Game1.State.Type == GameStates.Playing)
            {
                Game1.State.Pause();
            }
            else if(Game1.State.Type == GameStates.Pause)
            {
                Game1.State.Proceed();
            }

        }
    }
}