using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
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
            if (myhandler.mario.State.IsStar)
            {
                //Add score
            }
            else
            {
                switch (myhandler.mario.State.MarioShape)
                {
                    case Shape.Small:
                        myhandler.mario.State.MarioShape = Shape.Dead;
                        break;
                    case Shape.Big:
                        myhandler.mario.IsProtected = true;
                        break;
                    case Shape.Fire:
                        myhandler.mario.IsProtected = true;
                        break;
                }


            }
        }
    }
}
