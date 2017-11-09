using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class MarioGoombaCollisionRight : ICollisionCommand
    {
        public MarioGoombaCollisionRight()
        {

        }     

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            Goomba goomba = (Goomba)gameObject2;
            if (mario.State.MarioShape == Shape.Dead ||
                mario.IsProtected || !goomba.Alive)
            {
                return;
            }

            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - 1));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioGoombaCollisionTop();
                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }

            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                ICollisionCommand BottomCommand = new MarioGoombaCollisionBottom();
                BottomCommand.Execute(gameObject1, gameObject2);
                return;
            }

            if (goomba.Alive)
            {
                if (mario.State.IsStar == true)
                {
                    goomba.Terminate("RIGHT");
                }
                else
                {
                    goomba.ChangeDirection();
                    switch (mario.State.MarioShape)
                    {
                        case Shape.Small:
                            mario.State.Terminated();
                            break;
                        case Shape.Big:
                            mario.IsProtected = true;
                            mario.State.MarioShapeChange(Shape.Small);
                            break;
                        case Shape.Fire:
                            mario.IsProtected = true;
                            mario.State.MarioShapeChange(Shape.Small);
                            break;
                    }
                }
            }
        }
    }
}
