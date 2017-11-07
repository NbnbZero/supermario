using FlugelMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsEnemies
{
    class KoopaBlockCollisionLeft : ICollisionCommand
    {
        public KoopaBlockCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa = (Koopa)gameObject1;
            if(koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            int koopaPreY = (int)(koopa.Location.Y - (koopa.Velocity.Y - GameData.SinglePixel));
            if (koopaPreY + koopa.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (koopaPreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (koopa.Velocity.X > GameData.StationaryVelocity)
            {
                koopa.ChangeDirection();
            }
        }
    }
}
