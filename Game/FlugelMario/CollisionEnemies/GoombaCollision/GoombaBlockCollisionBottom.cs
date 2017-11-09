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
    class GoombaBlockCollisionBottom: ICommand
    {
        CollisionHandlerGoomba myhandler;
        public GoombaBlockCollisionBottom(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {      
            if(!myhandler.goomba1.Alive)
            {
                return;
            }
            myhandler.goomba1.Location = new Vector2(myhandler.goomba1.Location.X, myhandler.block.Location.Y + myhandler.block.Destination.Height);
            if (myhandler.goomba1.Velocity.Y > 0)
            {
                myhandler.goomba1.Velocity = new Vector2(myhandler.goomba1.Velocity.X, 0);                   
            }
        }
    }
}

