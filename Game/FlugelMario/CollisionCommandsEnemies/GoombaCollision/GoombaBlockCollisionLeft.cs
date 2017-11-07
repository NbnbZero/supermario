using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsEnemies
{
    class GoombaBlockCollisionLeft : ICollisionCommand
    {
        public GoombaBlockCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba = (Goomba)gameObject1;
            int goombaPreY = (int)(goomba.Location.Y - (goomba.Velocity.Y - GameData.SinglePixel));
            if (goombaPreY + goomba.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (goombaPreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (goomba.Velocity.X > GameData.StationaryVelocity)
            {
                goomba.ChangeDirection();
            }
        }
    }
}