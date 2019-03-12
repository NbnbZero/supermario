using FlugelMario.States.GameState;
using SuperMario.Interfaces;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.GameState
{
    public class PlayingState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.Playing;
            }
        }

        public PlayingState(AbstractGame _game)
        {
            this.game = _game;
        }

        public void GameOver()
        {
            Game1.State = new GameOverState(game);
        }

        public void MarioDied()
        {
             Game1.State = new LifeDisplayState(game);
        }

        public void Pause()
        {
            Game1.State = new PauseState(game);
        }

        public void PlayDemo()
        {

        }

        public void Proceed()
        {
             Game1.State = new LevelComplete(game);
        }

        public void Transit()
        {
        }
    }
}
