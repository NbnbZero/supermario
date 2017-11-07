using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class GoombaGoombaCollisionTop : ICollisionCommand
    {
        public GoombaGoombaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba goomba1 = (Goomba)gameObject1;
            goomba1.Location = new Vector2(goomba1.Location.X, gameObject2.Location.Y - goomba1.Destination.Height);
        }
    }
}
