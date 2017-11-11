using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.Interfaces;
using SuperMairo.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.SpriteFactories
{
    class TextSpriteFactory
    {
        private SpriteFont Font;

        private static TextSpriteFactory instance = new TextSpriteFactory();

        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private TextSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            Font = content.Load<SpriteFont>("File");
        }

        public IText CreateNormalFontTextSpriteSprite()
        {
            return new Text(Font);
        }
    }
}
