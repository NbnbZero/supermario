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
    class UpMushroomBlockCollisionTop : ICollisionCommand
    {
        public UpMushroomBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            UpMushroom upMushroom = (UpMushroom)gameObject1;
            if (upMushroom.IsPreparing)
            {
                return;
            }
            upMushroom.Location = new Vector2(upMushroom.Location.X, gameObject2.Location.Y - upMushroom.Destination.Height);
            upMushroom.Velocity = new Vector2(upMushroom.Velocity.X, 0);
        }
    }
}
