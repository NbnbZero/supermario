using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Enums;

namespace SuperMario
{
    public class MarioBlockCollisionTop : ICollisionCommand
    {
        public MarioBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            mario.IsInAir = false;
            mario.Location = new Vector2(mario.Destination.X, gameObject2.Destination.Y - mario.Destination.Height);
            
            if(mario.Velocity.Y > 0)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, 0);
            }
            
        }
    }
}
