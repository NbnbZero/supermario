
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
    class KoopaGoombaCollisionBottom : ICommand
    {
        CollisionHandlerKoopa myhandler;
        public KoopaGoombaCollisionBottom(CollisionHandlerKoopa handler)
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
            myhandler.goomba1.Location = new Vector2(myhandler.goomba1.Location.X, myhandler.koopa1.Location.Y - myhandler.goomba1.Destination.Height - 1);
        }
    }
}
