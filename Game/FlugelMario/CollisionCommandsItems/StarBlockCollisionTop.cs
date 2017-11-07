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
    class StarBlockCollisionTop:ICollisionCommand
    {
        private int starBounceVelocity = -5;
        public StarBlockCollisionTop()
        {
        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {

            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Star star = (Star)gameObject1;
            if (star.IsPreparing)
            {
                return;
            }

            star.Location = new Vector2(star.Location.X, gameObject2.Location.Y - star.Destination.Height);
            star.Velocity = new Vector2(star.Velocity.X, starBounceVelocity);
        }
    }
}
