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
    class KoopaKoopaCollisionTop : ICollisionCommand
    {
        public KoopaKoopaCollisionTop()
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
            koopa1.Location = new Vector2(koopa1.Location.X, gameObject2.Location.Y - koopa1.Destination.Height);
        }
    }
}
