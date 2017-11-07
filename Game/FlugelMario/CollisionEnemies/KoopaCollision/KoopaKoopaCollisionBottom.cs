using SuperMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class KoopaKoopaCollisionBottom : ICollisionCommand
    {
        public KoopaKoopaCollisionBottom()
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
            koopa2.Location = new Vector2(koopa2.Location.X, gameObject1.Location.Y - gameObject2.Destination.Height - 1);
        }
    }
}
