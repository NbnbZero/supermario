using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Commands
{
    class BlockMarioBottomCommand : ICommand
    {
        CollisionHandler myhandler;
        public BlockMarioBottomCommand(CollisionHandler handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, -myhandler.mario.Velocity.Y);
        }
    }
}
