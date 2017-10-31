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
        private List<Sprite> visibleSprites = new List<Sprite>();
        private Game1 game;
        private Camera camera;
        public CurrentViewport(Game1 game1)
        {
            Game = game1;
            if (game1 != null)
            {
                this.Camera = game1.camera;
            }
        }

        public Camera Camera { get => camera; set => camera = value; }
        public List<Sprite> VisibleSprites { get => visibleSprites; set => visibleSprites = value; }
        public Game1 Game { get => game; set => game = value; }

        public void Update()
        {
            Rectangle tmpR = new Rectangle((int)Camera.Position.X, (int)Camera.Position.Y, Camera.Limits.Value.Width, Camera.Limits.Value.Height);
            foreach (Sprite sprites in Game.Sprites)
            {
                if (sprites.CollisionRectangle.Intersects(tmpR))
                    VisibleSprites.Add(sprites);
            }
        }
    }

}
