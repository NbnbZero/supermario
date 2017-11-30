using SuperMario.Enums;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    class MarioItemCollision : ICommand
    {
        CollisionHandlerMario myhandler;
        public MarioItemCollision(CollisionHandlerMario handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.mario.State.MarioShape == Shape.Dead)
            {
                return;
            }

            if (myhandler.item.GetType() == typeof(Peach))
            {
                myhandler.item.IsCollected = true;
            }

            else if (!myhandler.item.IsCollected)
            {
                myhandler.item.Collect();
                if (myhandler.item.GetType() == typeof(FireFlower))
                {
                    switch (myhandler.mario.State.MarioShape)
                    {
                        case Shape.Small:
                            myhandler.mario.State.MarioShapeChange(Shape.Fire);
                            break;
                        case Shape.Big:
                            myhandler.mario.State.MarioShapeChange(Shape.Fire);
                            break;
                        case Shape.StarSmall:
                            myhandler.mario.State.MarioShapeChange(Shape.StarBig);
                            myhandler.mario.PreStarShape = Shape.Fire;
                            break;
                        case Shape.StarBig:
                            myhandler.mario.PreStarShape = Shape.Fire;
                            break;
                    }
                }
                else if (myhandler.item.GetType() == typeof(SuperMushroom))
                {
                    switch (myhandler.mario.State.MarioShape)
                    {
                        case Shape.Small:
                            myhandler.mario.State.MarioShapeChange(Shape.Big);
                            break;
                        case Shape.StarSmall:
                            myhandler.mario.State.MarioShapeChange(Shape.StarBig);
                            myhandler.mario.PreStarShape = Shape.Big;
                            break;
                    }
                }

                else if (myhandler.item.GetType() == typeof(UpMushroom))
                {
                }

                else if (myhandler.item.GetType() == typeof(Star))
                {

                    if (myhandler.mario.State.MarioShape != Shape.StarSmall &&
                    myhandler.mario.State.MarioShape != Shape.StarBig)
                    {
                        myhandler.mario.PreStarShape = myhandler.mario.State.MarioShape;
                        myhandler.mario.State.MarioShapeChange(Shape.StarSmall);
                    }
                }
                else if (myhandler.item.GetType() == typeof(Coin))
                {
                }
            }
        }
    }
}
