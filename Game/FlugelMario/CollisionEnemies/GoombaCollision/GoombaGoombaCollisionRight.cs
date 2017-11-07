using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.CollisionCommandsEnemies
{
    class GoombaGoombaCollisionRight : ICollisionCommand
    {
        public GoombaGoombaCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba1 = (Goomba)gameObject1;
            Goomba goomba2 = (Goomba)gameObject2;
            goomba1.Location = new Vector2(goomba1.Location.X + 1, goomba1.Location.Y);
            goomba1.ChangeDirection();
            goomba2.ChangeDirection();
        }
    }
}
