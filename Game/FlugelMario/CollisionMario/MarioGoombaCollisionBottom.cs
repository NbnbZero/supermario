using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    public class MarioGoombaCollisionBottom : ICollisionCommand
    {
        public MarioGoombaCollisionBottom()
        {
            
        }     
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IEnemy goomba = (IEnemy)gameObject2;
            if (mario.State.MarioShape == Shape.Dead || !goomba.Alive)
            {
                return;
            }
            goomba.Terminate("LEFT");
        }
    }
}
