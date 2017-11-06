using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsItems
{
    class SuperMushroomBlockCollisionTop:ICollisionCommand
    {
        public SuperMushroomBlockCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
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
        }
    }
}
