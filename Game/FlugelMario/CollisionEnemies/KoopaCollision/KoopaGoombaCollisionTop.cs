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
    class KoopaGoombaCollisionTop : ICollisionCommand
    {
        public KoopaGoombaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa = (Koopa)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            IEnemy goomba = (IEnemy)gameObject2;
            if (!goomba.Alive)
                return;
            koopa.Location = new Vector2(koopa.Location.X, gameObject2.Location.Y - koopa.Destination.Height);
        }
    }
}
