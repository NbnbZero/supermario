using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    public class MarioCoinCollisionLeft : ICollisionCommand
    {
        public MarioCoinCollisionLeft()
        {

        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IItem coin = (IItem)gameObject2;
            if (!coin.IsCollected)
            {
                coin.Collect();
            }
        }
    }
}
