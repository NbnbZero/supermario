using SuperMario.Interfaces;
using SuperMario;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.GameState
{
    public class GameOverState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.GameOver;
            }
        }

        public GameOverState(AbstractGame _game)
        {
            this.game = _game;
            SoundManager.Instance.PlayGameOverSound();
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
            Game1.State = new Title(game);
        }
    }
}
