using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Sound;
using SuperMairo.HeadsUp;

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
                myhandler.mario.Velocity = new Vector2(myhandler.mario.Velocity.X,GameData.marioBouncingSpeed);
                myhandler.enemy.Terminate("Top");
                SoundManager.Instance.PlayStompSound();
                ScoringSystem.AddPointsForStompingEnemy(myhandler.enemy);
            }
        }
    }
}
