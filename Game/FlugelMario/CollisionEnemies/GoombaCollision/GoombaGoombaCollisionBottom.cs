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
    class GoombaGoombaCollisionBottom : ICollisionCommand
    {
        public GoombaGoombaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba2 = (Goomba)gameObject2;
            goomba2.Location = new Vector2(goomba2.Location.X, gameObject1.Location.Y - gameObject2.Destination.Height - 1);
        }
    }
}
