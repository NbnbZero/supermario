using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    class MarioRMushroomCollisionBottom : ICollisionCommand
    {
        public MarioRMushroomCollisionBottom()
        {
        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IItem Redmush = (IItem)gameObject2;
            if (!Redmush.IsCollected)
            {
                Redmush.Collect();
                switch (mario.State.MarioShape)
                {
                    case Shape.Small:
                        mario.State.MarioShapeChange(Shape.Big);
                        break;
                    case Shape.StarSmall:
                        mario.State.MarioShapeChange(Shape.Big);
                        mario.PreStarShape = Shape.Big;
                        break;
                }
            }
        }
    }
}

