
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
    class KoopaBlockCollisionTop : ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaBlockCollisionTop(CollisionHandlerKoopa handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.block.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)myhandler.block;
                if (!hiddenBlock.Used) return;
            }

            if (myhandler.koopa1.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            myhandler.koopa1.Location = new Vector2(myhandler.koopa1.Location.X, myhandler.block.Location.Y - myhandler.koopa1.Destination.Height);

            myhandler.koopa1.Velocity = new Vector2(myhandler.koopa1.Velocity.X, 0);
        }
    }
}
