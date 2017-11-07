using SuperMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.CollisionCommandsEnemies
{
    class KoopaBlockCollisionBottom: ICollisionCommand
    {
        public KoopaBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa k = (Koopa)gameObject1;
            if (k.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            k.Location = new Vector2(k.Location.X, gameObject2.Location.Y - gameObject2.Destination.Height);
            if (k.Velocity.Y < 0)
            {
                k.Velocity = new Vector2(k.Velocity.X, 0);
            }
        }
    }
}
