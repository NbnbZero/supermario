
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class KoopaBlockCollisionLeft : ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaBlockCollisionLeft(CollisionHandlerKoopa handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {
            if(myhandler.koopa1.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            int koopaPreY = (int)(myhandler.koopa1.Location.Y - (myhandler.koopa1.Velocity.Y - 1));
            if (koopaPreY + myhandler.koopa1.Destination.Height <= myhandler.block.Location.Y)
            {
                return;
            }

            else if (koopaPreY > myhandler.block.Location.Y + myhandler.block.Destination.Height)
            {
                return;
            }
            if (myhandler.koopa1.Velocity.X > 0)
            {
                myhandler.koopa1.ChangeDirection();
            }
        }
    }
}
