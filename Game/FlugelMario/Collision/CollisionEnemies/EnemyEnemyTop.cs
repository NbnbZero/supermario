using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
namespace SuperMario.Commands
{
    public class EnemyEnemyTop : ICommand
    {
        CollisionHandlerEnemy handler;
        public EnemyEnemyTop(CollisionHandlerEnemy Handler)
        {
            handler = Handler;
        }
        public void Execute()
        {
            if (handler.enemy.GetType() == typeof(Blooper) || handler.enemy.GetType() == typeof(CheapCheap))
            {
                return;
            }
            handler.enemy.Location = new Vector2(handler.enemy.Location.X, handler.enemy.Location.Y- handler.enemy.Destination.Height+1);
            if (handler.another.Alive)
            {
                handler.enemy.Velocity = new Vector2(handler.enemy.Velocity.X,GameData.marioBouncingSpeed);
                handler.another.Terminate("RIGHT");
            }
            
        }
    }
}

