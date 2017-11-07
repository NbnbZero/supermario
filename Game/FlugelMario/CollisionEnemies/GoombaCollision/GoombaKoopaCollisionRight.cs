
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
    class GoombaKoopaCollisionRight : ICollisionCommand
    {
        public GoombaKoopaCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba = (Goomba)gameObject1;
            Koopa koopa = (Koopa)gameObject2;
            if (!goomba.Alive)
                return;
            goomba.Location = new Vector2(goomba.Location.X + GameData.SinglePixel, goomba.Location.Y);

            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != GameData.StationaryVelocity)
            {
                goomba.Terminate("RIGHT");
                return;
            }
            goomba.ChangeDirection();
            koopa.ChangeDirection();
        }
    }
}
