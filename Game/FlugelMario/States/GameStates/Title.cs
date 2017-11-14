using SuperMario.DisplayPanel;
using SuperMario.Interfaces;
using SuperMario;
using SuperMario.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.GameState
{
    public class Title : IGameState
    {
        private AbstractGame game;
        public GameStates Type
        {
            get
            {
                return GameStates.Title;
            }
        }

        public Title(AbstractGame _game)
        {
            game = _game;
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
            TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameData.GameObjectManager.TitlePanel;
        }
    }
}
