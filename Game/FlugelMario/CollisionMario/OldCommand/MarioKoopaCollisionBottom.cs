using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.States.EnemyStates;

namespace SuperMario
{
    public class MarioKoopaCollisionBottom : ICollisionCommand
    {
       
        public MarioKoopaCollisionBottom()
        {
        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            IEnemy koopa = (IEnemy)gameObject2;
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                return;
            }
            koopa.Terminate("DOWN");
        }
    }
}
