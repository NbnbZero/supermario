using SuperMario.States.EnemyStates;
using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class KoopaGoombaCollisionRight : ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaGoombaCollisionRight(CollisionHandlerKoopa handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {

            if (myhandler.koopa1.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }

            if (!myhandler.goomba1.Alive)
                return;
            myhandler.koopa1.Location = new Vector2(myhandler.koopa1.Location.X + 1, myhandler.koopa1.Location.Y);
            if (myhandler.koopa1.State.GetType() == typeof(KoopaDeadState) &&
                myhandler.koopa1.Velocity.X != 0)
            {
                myhandler.goomba1.Terminate("RIGHT");
                return;
            }
            myhandler.koopa1.ChangeDirection();
            myhandler.goomba1.ChangeDirection();
        }
    }
}
