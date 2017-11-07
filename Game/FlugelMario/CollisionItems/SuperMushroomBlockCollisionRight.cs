using SuperMario;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsItems
{
    class SuperMushroomBlockCollisionRight:ICollisionCommand
    {
        public SuperMushroomBlockCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
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
        }
    }
}
