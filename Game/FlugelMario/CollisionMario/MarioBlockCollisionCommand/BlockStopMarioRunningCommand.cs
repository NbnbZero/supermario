using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.MarioStates;
namespace SuperMario.Commands
{
    public class BlockStopMarioRunningCommand:ICommand
    {
        
        CollisionHandlerMario myhandler;
        public BlockStopMarioRunningCommand(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
        }
        
    }
}
