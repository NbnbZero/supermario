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
    class KoopaKoopaCollisionLeft : ICollisionCommand
    {
        public KoopaKoopaCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa1 = (Koopa)gameObject1;
            if (koopa1.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            Koopa koopa2 = (Koopa)gameObject2;
            if (koopa2.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }

            if (koopa1.State.GetType() == typeof(KoopaDeadState) &&
                koopa1.Velocity.X != GameData.StationaryVelocity)
            {
                koopa2.Terminate("DOWN");
                return;
            }
            if (koopa2.State.GetType() == typeof(KoopaDeadState) &&
                koopa2.Velocity.X != GameData.StationaryVelocity)
            {
                koopa1.Terminate("DOWN");
                return;
            }

            koopa1.Location = new Vector2(koopa1.Location.X - GameData.SinglePixel, koopa1.Location.Y);
            koopa1.ChangeDirection();
            koopa2.ChangeDirection();
        }
    }
}