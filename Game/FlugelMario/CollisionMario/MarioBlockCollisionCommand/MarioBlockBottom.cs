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
            myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, -myhandler.mario.Velocity.Y);

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
