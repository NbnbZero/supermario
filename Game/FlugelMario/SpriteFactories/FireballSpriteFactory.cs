using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;
using FlugelMario.Sprites.Fireball;
using Microsoft.Xna.Framework;

namespace FlugelMario.SpriteFactories
{
    class FireballSpriteFactory
    {
        public int FireballSpriteColumn { get; } = 4;
        public int FireballSpriteRow { get; } = 1;        
        public int FireballTotalFrame { get; } = 4;
        
        private Texture2D FireballSpritesheet;

        private static FireballSpriteFactory instance = new FireballSpriteFactory();
        public static FireballSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private FireballSpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            FireballSpritesheet = content.Load<Texture2D>("Fireball");
        }

        public int FireballWidth
        {
            get
            {
                return FireballSpritesheet.Width / FireballSpriteColumn;
            }
        }

        public int FireballHeight
        {
            get
            {
                return FireballSpritesheet.Height / FireballSpriteRow;
            }
        }
        public ISprite CreateFireball()
        {
            return new FireballSprite(FireballSpritesheet);
        }

        public Vector2 FireballSpriteCord { get; } = new Vector2(0, 0);
    }
}
