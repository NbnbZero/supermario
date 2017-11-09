using Microsoft.Xna.Framework;
using SuperMario;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    public class MarioPipeTwoSide : ICommand
    {

        CollisionHandlerMario myhandler;
        public MarioPipeTwoSide(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
        }

    }
}
