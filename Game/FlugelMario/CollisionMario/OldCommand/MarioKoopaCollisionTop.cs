using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.States.EnemyStates;
using SuperMario.Enums;

namespace SuperMario
{
    public class MarioKoopaCollisionTop : ICollisionCommand
    {
        public MarioKoopaCollisionTop()
        {
        }       

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            Koopa koopa = (Koopa)gameObject2;
            if (mario.State.MarioShape == Shape.Dead ||
                mario.IsProtected || !koopa.Alive)
            {
                return;
            }

            mario.Location = new Vector2(mario.Destination.X, koopa.Location.Y - mario.Destination.Height - 1);
            mario.Velocity = new Vector2(mario.Velocity.X, -2); //bounce up

            if (koopa.State.GetType() != typeof(KoopaDeadState))
            {
                koopa.Terminate("UP");
                koopa.Velocity = new Vector2(0, koopa.Velocity.Y);               
            }
        }
    }
}
