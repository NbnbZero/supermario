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
    class GoombaBlockCollisionBottom: ICollisionCommand
    {
        public GoombaBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba g = (Goomba)gameObject1;
            
            if(!g.Alive)
            {
                return;
            }
            g.Location = new Vector2(g.Location.X, gameObject2.Location.Y + gameObject2.Destination.Height);
            if (g.Velocity.Y > 0)
            {
                g.Velocity = new Vector2(g.Velocity.X, 0);                   
            }
        }
    }
}

