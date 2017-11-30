using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.GameObjects.ItemGameObjects;
using SuperMario.GameObjects;
using SuperMario.Sound;

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
            if (myhandler.block.GetType() == typeof(UnderwaterBlock))
            {
                myhandler.mario.Location = new Vector2(myhandler.mario.Destination.X, myhandler.block.Destination.Y + myhandler.block.Destination.Height - 1);
            }
            myhandler.mario.Location = new Vector2(myhandler.mario.Destination.X, myhandler.block.Destination.Y + myhandler.block.Destination.Height - 1);
            if (myhandler.mario.Velocity.Y < 0) { 
                myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, 0);
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
                    SoundManager.Instance.PlayBumpSound();
                }
                
                if ((myhandler.mario.State.MarioShape == Shape.Big ||
                    myhandler.mario.State.MarioShape == Shape.Fire ||
                    myhandler.mario.State.MarioShape == Shape.StarBig)
                    && myhandler.block.GetType() == typeof(QuestionBlock))
                {
                    myhandler.block.Trigger();
                    SoundManager.Instance.PlayBumpSound();
                }
            }
        }
    }
}
