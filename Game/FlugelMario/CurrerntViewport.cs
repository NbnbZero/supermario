using FlugelMario;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class CurrentViewport
    {
        public List<Sprite> VisibleSprites = new List<Sprite>();
        public Game1 game;
        public Camera camera;
        public CurrentViewport(Game1 game1)
        {
            game = game1;
            this.camera = game1.camera;
        }

        public void Update()
        {
            Rectangle tmpR = new Rectangle((int)camera.Position.X, (int)camera.Position.Y, camera.Limits.Value.Width, camera.Limits.Value.Height);
            foreach (Sprite sprites in game.Sprites)
            {
                if (sprites.CollisionRectangle.Intersects(tmpR))
                    VisibleSprites.Add(sprites);
            }
        }
    }

}
