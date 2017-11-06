using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class QuitGameCommand : ICommand
    {
        private Game1 mygame;

        public QuitGameCommand(Game1 game)
        {
            mygame = game;
        }

        public void Execute()
        {
            mygame.Exit();
        }
    }
}

