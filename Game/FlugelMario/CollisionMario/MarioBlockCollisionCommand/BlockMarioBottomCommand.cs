using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Commands
{
    class BlockMarioBottomCommand : ICommand
    {
        CollisionHandlerMario myhandler;
        public BlockMarioBottomCommand(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, -myhandler.mario.Velocity.Y);
        }
    }
}
