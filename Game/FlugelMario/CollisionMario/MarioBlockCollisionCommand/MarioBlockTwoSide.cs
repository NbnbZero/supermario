using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
namespace SuperMario.Commands
{
    public class MarioBlockTwoSide : ICommand
    {
        
        CollisionHandlerMario myhandler;
        public MarioBlockTwoSide(CollisionHandlerMario handler)
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

            if (marioPreY + myhandler.mario.Destination.Height <= myhandler.block.Destination.Y)
            {
                return;
            }
            else if (marioPreY > myhandler.block.Destination.Y + myhandler.block.Destination.Height)
            {
                return;
            }
            CollisionDirection side = CollisionDetector.DetectCollisionDirection(myhandler.mario.Destination, myhandler.block.Destination);
            if (side == CollisionDirection.Left)
            {
                myhandler.mario.Location = new Vector2(myhandler.block.Destination.X - myhandler.block.Destination.Width - 3, myhandler.mario.Destination.Y);
            }else if (side == CollisionDirection.Right)
            {
                myhandler.mario.Location = new Vector2(myhandler.block.Destination.X + myhandler.block.Destination.Width + 3, myhandler.mario.Destination.Y);
            }

            if (myhandler.mario.Velocity.X > 0)
            {
                myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
            }
            
           
    
            
        }
        
    }
}
