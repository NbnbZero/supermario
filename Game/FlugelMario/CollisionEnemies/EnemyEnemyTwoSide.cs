using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

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
            handler.enemy.Location = new Vector2(handler.enemy.Location.X - 1, handler.enemy.Location.Y);
            handler.enemy.ChangeDirection();
            handler.another.ChangeDirection();
        }
    }
}
