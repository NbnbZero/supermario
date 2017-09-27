using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;
namespace FlugelMario
{
    class PauseGame:ICommand
    {
        private Game1 mygame;
        public PauseGame(Game1 game)
        {
            mygame = game;
        }

        public void Execute()
        {
            mygame.isPause = false;
        }

        public void Execute(InputState state, IMarioState marioState)
        {
        }



    }
}
