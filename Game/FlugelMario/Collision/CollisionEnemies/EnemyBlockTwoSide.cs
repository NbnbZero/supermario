using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using SuperMario.GameObjects;

namespace SuperMario.Commands
{
    public class EnemyBlockTwoSide : ICommand
    {

        CollisionHandlerEnemy myhandler;
        public EnemyBlockTwoSide(CollisionHandlerEnemy handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.block.GetType() == typeof(HiddenBlock) || 
                myhandler.enemy.GetType() == typeof(Blooper) || myhandler.enemy.GetType() == typeof(CheapCheap))
            {
                return;
            }
            if (myhandler.enemy.Velocity.X != 0)
            {
                myhandler.enemy.ChangeDirection();
            }            
        }

    }
}
