using SuperMario.Interfaces;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.GameState
{
    public class LifeDisplayState : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.LifeDisplay;
            }
        }

        public LifeDisplayState(AbstractGame _game)
        {
            this.game = _game;
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
    }
}
