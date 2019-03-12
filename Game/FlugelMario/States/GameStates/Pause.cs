using SuperMario.Interfaces;
using SuperMario.States.GameState;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.States.GameState
{
    public class PauseState : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.Pause;
            }
        }

        public PauseState(AbstractGame game)
        {
            this.game = game;
        }

        public void GameOver()
        {

        }

        public void MarioDied()
        {

        }

        public void Pause()
        {

        }

        public void PlayDemo()
        {

        }

        public void Proceed()
        {
            Game1.State = new PlayingState(game);
        }

        public void Transit()
        {
        }
    }
}
