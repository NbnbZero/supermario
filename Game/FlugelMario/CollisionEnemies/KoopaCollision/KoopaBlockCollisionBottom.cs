using SuperMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario
{
    class KoopaBlockCollisionBottom: ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaBlockCollisionBottom(CollisionHandlerKoopa handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            if (myhandler.koopa1.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            myhandler.koopa1.Location = new Vector2(myhandler.koopa1.Location.X, myhandler.block.Location.Y - myhandler.block.Destination.Height);
            if (myhandler.koopa1.Velocity.Y < 0)
            {
                myhandler.koopa1.Velocity = new Vector2(myhandler.koopa1.Velocity.X, 0);
            }
        }
    }
}
