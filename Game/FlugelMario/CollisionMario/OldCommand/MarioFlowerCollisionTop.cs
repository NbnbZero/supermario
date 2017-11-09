using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Enums;
using SuperMario.Interfaces;

namespace SuperMario
{
    class MarioFlowerCollisionTop : ICollisionCommand
    {
        public MarioFlowerCollisionTop()
        {
        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IItem flower = (IItem)gameObject2;
            if (!flower.IsCollected)
            {
                flower.Collect();
                switch (mario.State.MarioShape)
                {
                    case Shape.Small:
                        mario.State.MarioShapeChange(Shape.Fire);
                        break;
                    case Shape.Big:
                        mario.State.MarioShapeChange(Shape.Fire);
                        break;
                    case Shape.StarSmall:
                        mario.State.MarioShapeChange(Shape.Fire);
                        mario.PreStarShape = Shape.Fire;
                        break;
                    case Shape.StarBig:
                        mario.PreStarShape = Shape.Fire;
                        break;
                }
            }
        }
    }
}
