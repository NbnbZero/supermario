using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    class MarioStarCollisionBottom : ICollisionCommand
    {
        public MarioStarCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IItem star = (IItem)gameObject2;
            if (!star.IsCollected)
            {
                star.Collect();
                if(mario.State.MarioShape != Shape.StarSmall &&
                    mario.State.MarioShape != Shape.StarBig)
                {
                    mario.State.MarioShapeChange(Shape.StarSmall);
                }
            }
        }
    }
}