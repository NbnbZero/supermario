using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class UpMushroomBlockCollisionRight : ICollisionCommand
    {
        public UpMushroomBlockCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            UpMushroom upMushroom = (UpMushroom)gameObject1;
            if (upMushroom.IsPreparing)
            {
                return;
            }
            int upMushroomPreY = (int)(upMushroom.Destination.Y - (upMushroom.Velocity.Y - 1));
            if (upMushroomPreY + upMushroom.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }else if (upMushroomPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            upMushroom.ChangeDirection();
        }
    }
}
