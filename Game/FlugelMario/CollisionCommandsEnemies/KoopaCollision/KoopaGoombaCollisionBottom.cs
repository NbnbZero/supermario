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
    class KoopaGoombaCollisionBottom : ICollisionCommand
    {
        public KoopaGoombaCollisionBottom()
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
            goomba.Location = new Vector2(goomba.Location.X, koopa.Location.Y - gameObject2.Destination.Height - GameData.SinglePixel);
        }
    }
}
