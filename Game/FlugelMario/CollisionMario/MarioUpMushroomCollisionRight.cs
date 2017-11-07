using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    class MarioUpMushroomCollisionRight : ICollisionCommand
    {
        public MarioUpMushroomCollisionRight()
        {
        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IItem Upmush = (IItem)gameObject2;
            if (!Upmush.IsCollected)
            {
                Upmush.Collect();
            }
        }
    }
}