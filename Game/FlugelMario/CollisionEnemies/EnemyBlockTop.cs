using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands
{
    class EnemyBlockTop : ICommand
    {
        CollisionHandlerEnemy myhandler;
        public EnemyBlockTop(CollisionHandlerEnemy handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (!myhandler.enemy.Alive)
            {
                return;
            }
            myhandler.enemy.Location = new Vector2(myhandler.enemy.Location.X, myhandler.enemy.Location.Y - myhandler.enemy.Destination.Height);
            
            myhandler.enemy.Velocity = new Vector2(myhandler.enemy.Velocity.X, 0);
        }
    }
}
