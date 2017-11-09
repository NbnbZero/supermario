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
    public class MarioGoombaCollisionTop : ICollisionCommand
    {
        public MarioGoombaCollisionTop()
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
            
            mario.Location = new Vector2(mario.Location.X, goomba.Location.Y - mario.Destination.Height + 1);
            if (goomba.Alive)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, -2);     //bounce up     
                goomba.Terminate("TOP");
            }
                
        }
    }
}
