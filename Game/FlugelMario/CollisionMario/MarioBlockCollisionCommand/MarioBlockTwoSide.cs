using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.MarioStates;
namespace SuperMario.Commands
{
    public class MarioBlockTwoSide : ICommand
    {
        
        CollisionHandler myhandler;
        public MarioBlockTwoSide(CollisionHandler handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            myhandler.mario.Velocity = new Vector2(0, myhandler.mario.Velocity.Y);
        }
        
    }
}
