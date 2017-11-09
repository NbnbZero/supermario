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
    class GoombaGoombaCollisionBottom : ICommand
    {
        CollisionHandlerGoomba myhandler;
        public GoombaGoombaCollisionBottom(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            myhandler.goomba2.Location = new Vector2(myhandler.goomba2.Location.X, myhandler.goomba1.Location.Y - myhandler.goomba2.Destination.Height - 1);
        }
    }
}
