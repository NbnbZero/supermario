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
    class SuperMushroomBlockCollisionTop:ICommand
    {
        CollisionHandlerSuperMushroom myhandler;
        public SuperMushroomBlockCollisionTop(CollisionHandlerSuperMushroom handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            /*
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            SuperMushroom superMushroom = (SuperMushroom)gameObject1;
            if (superMushroom.IsPreparing)
            {
                return;
            }
            superMushroom.Location = new Vector2(superMushroom.Location.X, gameObject2.Location.Y - superMushroom.Destination.Height);

            superMushroom.Velocity = new Vector2(superMushroom.Velocity.X, 0);
            */
            if (myhandler.block.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)myhandler.block;
                if (!hiddenBlock.Used) return;
            }

            SuperMushroom superMushroom = (SuperMushroom)myhandler.superMushroom1;
            if (superMushroom.IsPreparing)
            {
                return;
            }
            myhandler.superMushroom1.Location = new Vector2(myhandler.superMushroom1.Location.X, myhandler.block.Location.Y - myhandler.superMushroom1.Destination.Height);

            myhandler.superMushroom1.Velocity = new Vector2(myhandler.superMushroom1.Velocity.X, 0);

        }
    }
}
