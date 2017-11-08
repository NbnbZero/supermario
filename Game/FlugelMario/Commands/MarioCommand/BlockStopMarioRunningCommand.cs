using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.MarioStates;
namespace SuperMario.Commands
{
    public class BlockStopMarioRunningCommand:ICommand
    {
        
        CollisionHandler myhandler;
        public BlockStopMarioRunningCommand(CollisionHandler handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
        }
        
    }
}
