using FlugelMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.HeadsUp;
using SuperMario.Interfaces;
using SuperMario.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsEnemies
{
    class KoopaGoombaCollisionRight : ICollisionCommand
    {
        public KoopaGoombaCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa = (Koopa)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            Goomba goomba = (Goomba)gameObject2;
            if (!goomba.Alive)
                return;
            koopa.Location = new Vector2(koopa.Location.X + GameData.SinglePixel, koopa.Location.Y);
            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != GameData.StationaryVelocity)
            {
                goomba.Terminate("RIGHT");
                return;
            }
            koopa.ChangeDirection();
            goomba.ChangeDirection();
        }
    }
}
