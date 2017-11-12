using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    class MarioPipeTop : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioPipeTop(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (myhandler.mario.Velocity.Y >= 0)
            {
                myhandler.mario.IsInAir = false;
            }
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, 0);
            myhandler.mario.Location = new Vector2(myhandler.mario.Destination.X, myhandler.pipe.Destination.Y - myhandler.mario.Destination.Height);
        }
    }
}
