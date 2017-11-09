using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.GameObjects.ItemGameObjects;
using SuperMario.GameObjects;
namespace SuperMario.Commands
{
    class MarioBlockBottom : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioBlockBottom(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }
      
        public void Execute()
        {
            if (myhandler.mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (myhandler.block.GetType() == typeof(HiddenBlock) && myhandler.mario.Velocity.Y >= 0)
            {
                return;
            }
            myhandler.mario.Location = new Vector2(myhandler.mario.Destination.X, myhandler.block.Destination.Y + myhandler.block.Destination.Height - 1);
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, -myhandler.mario.Velocity.Y);
            if (!((myhandler.mario.State.MarioShape == Shape.Small ||
                    myhandler.mario.State.MarioShape == Shape.StarSmall) &&
                    (myhandler.block.GetType() == typeof(BrickBlock))))
            {
                myhandler.block.Trigger();
            }

            if ((myhandler.mario.State.MarioShape == Shape.Small ||
                    myhandler.mario.State.MarioShape == Shape.StarSmall) &&
                    (myhandler.block.GetType() == typeof(BrickBlock)))
            {
                int verticalDisplacement = 5;
                myhandler.block.Location = new Vector2(myhandler.block.Location.X, myhandler.block.Location.Y - verticalDisplacement);
            }
        }
    }
}
