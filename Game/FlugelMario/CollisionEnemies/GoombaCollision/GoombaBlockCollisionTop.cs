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
    class GoombaBlockCollisionTop : ICommand
    {
        CollisionHandlerGoomba myhandler;
        public GoombaBlockCollisionTop(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            
            if (myhandler.block.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)myhandler.block;
                if (!hiddenBlock.Used) return;
            }

            if (!myhandler.goomba1.Alive)
            {
                  return;
            }
            myhandler.goomba1.Location = new Vector2(myhandler.goomba1.Location.X, myhandler.block.Location.Y - myhandler.goomba1.Destination.Height);
            myhandler.goomba1.Velocity = new Vector2(myhandler.goomba1.Velocity.X, 0);
        }
    }
}
