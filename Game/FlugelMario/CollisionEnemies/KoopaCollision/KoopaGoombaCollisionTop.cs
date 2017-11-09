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
    class KoopaGoombaCollisionTop : ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaGoombaCollisionTop(CollisionHandlerKoopa handler)
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
            myhandler.koopa1.Location = new Vector2(myhandler.koopa1.Location.X, myhandler.goomba1.Location.Y - myhandler.koopa1.Destination.Height);
        }
    }
}
