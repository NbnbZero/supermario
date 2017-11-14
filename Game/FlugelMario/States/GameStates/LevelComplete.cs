using SuperMairo.Interfaces;
using SuperMairo.States.GameState;
using SuperMario;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.States.GameState
{
    public class LevelComplete : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.GameComplete;
            }
        }

        public LevelComplete(AbstractGame _game)
        {
            this.game = _game;
            SoundManager.Instance.StopAllSound();
            SoundManager.Instance.PlayGameCompleteSound();
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
            Game1.State = new Victory(game);
        }
    }
}
