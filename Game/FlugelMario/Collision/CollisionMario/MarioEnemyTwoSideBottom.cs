using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Sound;

namespace SuperMario.Commands
{
    class MarioEnemyTwoSideBottom : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioEnemyTwoSideBottom(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.mario.State.MarioShape == Shape.Dead ||
               myhandler.mario.IsProtected || !myhandler.enemy.Alive)
            {
                return;
            }

            int marioPreY = (int)(myhandler.mario.Destination.Y - (myhandler.mario.Velocity.Y - 1));
            if (marioPreY + myhandler.mario.Destination.Height < myhandler.enemy.Destination.Y)
            {
                ICommand TopCommand = new MarioEnemyTop(myhandler);
                TopCommand.Execute();
                return;
            }

            if (myhandler.enemy.Alive)
            {
                if (myhandler.mario.State.IsStar)
                {
                    //Add score
                    myhandler.enemy.Terminate("Right");
                }
                else
                {
                    myhandler.enemy.ChangeDirection();
                    switch (myhandler.mario.State.MarioShape)
                    {
                        case Shape.Small:
                            myhandler.mario.State.Terminated();
                            break;
                        case Shape.Big:
                            myhandler.mario.IsProtected = true;
                            myhandler.mario.State.MarioShapeChange(Shape.Small);
                            SoundManager.Instance.PlayPipeSound();
                            break;
                        case Shape.Fire:
                            myhandler.mario.IsProtected = true;
                            myhandler.mario.State.MarioShapeChange(Shape.Small);
                            SoundManager.Instance.PlayPipeSound();
                            break;
                    }
                }
            }
        }
    }
}
