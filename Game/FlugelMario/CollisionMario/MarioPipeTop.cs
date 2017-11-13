using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.GameObjects.PipeGameObjects;

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


            if (myhandler.mario.State.MarioPosture == Posture.Crouch &&
                myhandler.pipe.GetType() == typeof(GameObjects.BigPipe))
            {
                myhandler.pipe.Warp(myhandler.mario);
            }
        }
    }
}
