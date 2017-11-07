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
    class GoombaKoopaCollisionBottom : ICollisionCommand
    {
        public GoombaKoopaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IEnemy goomba1 = (IEnemy)gameObject1;
            if (!goomba1.Alive)
                return;
            gameObject2.Location = new Vector2(gameObject2.Location.X, goomba1.Location.Y - gameObject2.Destination.Height - GameData.SinglePixel);
        }
    }
}
