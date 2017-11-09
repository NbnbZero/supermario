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
    class GoombaKoopaCollisionLeft : ICommand
    {
        CollisionHandlerGoomba myhandler;

        public GoombaKoopaCollisionLeft(CollisionHandlerGoomba handler)
        {
            myhandler = handler;
        }
        public void Execute()
        {

            myhandler.goomba1.Location = new Vector2(myhandler.goomba1.Location.X - 1, myhandler.goomba1.Location.Y);

            if (!myhandler.goomba1.Alive)
                return;
            if (myhandler.koopa1.State.GetType() == typeof(KoopaDeadState) &&
                myhandler.koopa1.Velocity.X != 0)
            {
                myhandler.goomba1.Terminate("LEFT");
                return;
            }
            myhandler.goomba1.ChangeDirection();
            myhandler.koopa1.ChangeDirection();
        }
    }
}
