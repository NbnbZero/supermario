using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.States.EnemyStates;

namespace SuperMario.Commands
{
    public class EnemyEnemyTwoSide:ICommand
    {
        CollisionHandlerEnemy handler;
        public EnemyEnemyTwoSide(CollisionHandlerEnemy Handler)
        {
            handler = Handler;
        }

        public void Execute()
        {
            if (handler.enemy.GetType() == typeof(Blooper) || handler.enemy.GetType() == typeof(CheapCheap))
            {
                return;
            }
            handler.enemy.Location = new Vector2(handler.enemy.Location.X - 1, handler.enemy.Location.Y);
            if (handler.enemy.GetType() == typeof(Goomba))
            {
                if(!handler.enemy.Alive) return;
                if (handler.another.State.GetType() == typeof(KoopaDeadState) && handler.another.Velocity.X != 0)
                {
                    handler.enemy.Terminate("Left");
                    return;
                }
            }
            if (handler.enemy.GetType() == typeof(Koopa))
            {
                if (handler.enemy.State.GetType() == typeof(KoopaDeadState))
                {
                    return;
                }
                if (!handler.another.Alive)
                {
                    return;
                }
                if (handler.enemy.State.GetType() == typeof(KoopaDeadState) && handler.enemy.Velocity.X != 0)
                {
                    handler.another.Terminate("Left");
                    return;
                }
            }
            handler.enemy.Location = new Vector2(handler.enemy.Location.X - 1, handler.enemy.Location.Y);
            handler.enemy.ChangeDirection();
            handler.another.ChangeDirection();
        }
    }
}
