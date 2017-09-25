using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;

namespace FlugelMario.Commnad.MarioCommand
{
    class ExitCommand : ICommand
    {
        Game1 myGame;
        public ExitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();

        }
    }
}
