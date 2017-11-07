using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.Enums;

namespace SuperMario
{
    public class MarioKoopaCollisionLeft : ICollisionCommand
    {
        public MarioKoopaCollisionLeft()
        {
        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa koopa = (Koopa)gameObject2;
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead ||
                mario.IsProtected || !koopa.Alive)
            {
                return;
            }

            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - 1));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioKoopaCollisionTop();
                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }

            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                ICollisionCommand BottomCommand = new MarioKoopaCollisionBottom();
                BottomCommand.Execute(gameObject1, gameObject2);
                return;
            }

            if (koopa.Alive)
            {
                if (mario.State.IsStar == true)
                {
                    koopa.Terminate("DOWN");
                }
                else
                {
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
                    mario.Location = new Vector2(mario.Location.X, mario.Location.Y);
                }
            }
        }
    }
}
