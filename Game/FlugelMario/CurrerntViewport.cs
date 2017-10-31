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
        private Camera camera;
        public CurrentViewport(Game1 game1)
        {
            game = game1;
            this.Camera = game1.camera;
        }

        public Camera Camera { get => camera; set => camera = value; }

        public void Update()
        {
            Rectangle tmpR = new Rectangle((int)Camera.Position.X, (int)Camera.Position.Y, Camera.Limits.Value.Width, Camera.Limits.Value.Height);
            foreach (Sprite sprites in game.Sprites)
            {
                if (sprites.CollisionRectangle.Intersects(tmpR))
                    VisibleSprites.Add(sprites);
            }
        }
    }

}
