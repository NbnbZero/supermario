using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class GoombaGoombaCollisionLeft : ICommand
    {
        CollisionHandlerGoomba myhandler;
        public GoombaGoombaCollisionLeft(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            myhandler.goomba1.Location = new Vector2(myhandler.goomba1.Location.X - 1, myhandler.goomba1.Location.Y);
            myhandler.goomba1.ChangeDirection();
            myhandler.goomba2.ChangeDirection();
        }
    }
}
