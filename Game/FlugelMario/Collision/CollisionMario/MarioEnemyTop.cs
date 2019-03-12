using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Sound;
using SuperMario.SCsystem;

namespace SuperMario.Commands
{
    class MarioEnemyTop : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioEnemyTop(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.mario.State.MarioShape == Shape.Dead || !myhandler.enemy.Alive)
            {
                return;
            }
            myhandler.mario.Location = new Vector2(myhandler.mario.Location.X, myhandler.enemy.Location.Y - myhandler.mario.Destination.Height + 1 );

            if (myhandler.enemy.Alive)
            {
                if (!myhandler.mario.IsInWater)
                {
                    myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X, GameData.marioBouncingSpeed);
                    myhandler.enemy.Terminate("Top");
                    SoundManager.Instance.PlayStompSound();
                    ScoringSystem.AddPointsForStompingEnemy(myhandler.enemy);
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
