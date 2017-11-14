using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Interfaces
{
    public enum GameStates
    {
        Title, Demo, Playing, Pause, GameComplete, LevelComplete, 
        LifeDisplay, GameOver, Victory
    }

    public interface IGameState
    {
        GameStates Type { get; }
        void Proceed();
        void PlayDemo();
        void Pause();
        void MarioDied();
        void GameOver();
    }
}
