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
    class GoombaBlockCollisionLeft : ICommand
    {
        CollisionHandlerGoomba myhandler;
        public GoombaBlockCollisionLeft(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            int goombaPreY = (int)(myhandler.goomba1.Location.Y - (myhandler.goomba1.Velocity.Y - 1));
            if (goombaPreY + myhandler.goomba1.Destination.Height <= myhandler.block.Location.Y)
            {
                return;
            }

            else if (goombaPreY > myhandler.block.Location.Y + myhandler.block.Destination.Height)
            {
                return;
            }
            if (myhandler.goomba1.Velocity.X > 0)
            {
                myhandler.goomba1.ChangeDirection();
            }
        }
    }
}