using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class UpMushroomBlockCollisionBottom:ICollisionCommand
    {
        public UpMushroomBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            UpMushroom upMushroom = (UpMushroom)gameObject1;
            if (gameObject2.GetType() == typeof(HiddenBlock) && upMushroom.Velocity.Y >= 0)
            {
                return;
            }
        }
    }
}
