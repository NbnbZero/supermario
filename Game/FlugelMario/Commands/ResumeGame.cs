using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;
namespace FlugelMario
{
    class ResumeGame : ICommand
    {
        private Game1 mygame;
        public ResumeGame(Game1 game)
        {
            mygame = game;
        }

        public void Execute()
        {
            mygame.isPause = true;
        }

        public void Execute(InputState state, IMarioState marioState)
        {
        }



    }
}
