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
    class SuperMushroomBlockCollisionLeft:ICommand
    {
        CollisionHandlerSuperMushroom myhandler;
        public SuperMushroomBlockCollisionLeft(CollisionHandlerSuperMushroom handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            /*
            SuperMushroom superMushroom = (SuperMushroom)gameObject1;
            if (superMushroom.IsPreparing)
            {
                return;
            }
            int superMushroomPreY = (int)(superMushroom.Destination.Y - (superMushroom.Velocity.Y - 1));
            if (superMushroomPreY + superMushroom.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (superMushroomPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            superMushroom.ChangeDirection();
            */
            if (myhandler.superMushroom1.IsPreparing)
            {
                return;
            }
            int superMushroomPreY = (int)(myhandler.superMushroom1.Destination.Y - (myhandler.superMushroom1.Velocity.Y - 1));
            if (superMushroomPreY + myhandler.superMushroom1.Destination.Height <= myhandler.block.Destination.Y)
            {
                return;
            }

            else if (superMushroomPreY > myhandler.block.Destination.Y + myhandler.block.Destination.Height)
            {
                return;
            }
            myhandler.superMushroom1.ChangeDirection();

        }
    }
}
