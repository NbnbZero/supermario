using Microsoft.Xna.Framework;
using SuperMario;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.GameObjects.PipeGameObjects;
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
            if (myhandler.mario.State.MarioShape == Shape.Dead)
            {
                return;
            }

            int marioPreY = (int)(myhandler.mario.Destination.Y - (myhandler.mario.Velocity.Y - 1));

            if (marioPreY + myhandler.mario.Destination.Height <= myhandler.pipe.Destination.Y)
            {
                return;
            }
            else if (marioPreY > myhandler.pipe.Destination.Y + myhandler.pipe.Destination.Height)
            {
                return;
            }
            CollisionDirection side = CollisionDetector.DetectCollisionDirection(myhandler.mario.Destination, myhandler.pipe.Destination);
            if (side == CollisionDirection.Left)
            {
                myhandler.mario.Location = new Vector2(myhandler.pipe.Destination.X - myhandler.pipe.Destination.Width + 20, myhandler.mario.Destination.Y);
            }
            else if (side == CollisionDirection.Right)
            {
                myhandler.mario.Location = new Vector2(myhandler.pipe.Destination.X + myhandler.pipe.Destination.Width + 3, myhandler.mario.Destination.Y);
            }

            if (myhandler.mario.Velocity.X > 0)
            {
                myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
            }

            if (myhandler.pipe.GetType() == typeof(LPipeBottom))
            {
                LPipeBottom pipe = (LPipeBottom)myhandler.pipe;
                if (pipe.IsTelable)
                {
                    pipe.Warp(myhandler.mario);
                }
            }
        }

    }
}
