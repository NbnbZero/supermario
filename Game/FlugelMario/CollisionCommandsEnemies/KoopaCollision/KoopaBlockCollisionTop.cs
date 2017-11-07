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
    class KoopaBlockCollisionTop : ICollisionCommand
    {
        public KoopaBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Koopa koopa = (Koopa)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            koopa.Location = new Vector2(koopa.Location.X, gameObject2.Location.Y - koopa.Destination.Height);
        
            koopa.Velocity = new Vector2(koopa.Velocity.X, GameData.StationaryVelocity);
        }
    }
}
