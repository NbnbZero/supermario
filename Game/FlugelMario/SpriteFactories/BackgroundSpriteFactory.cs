using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sprites.Background;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.SpriteFactories
{
    public class BackgroundSpriteFactory
    {
        private Texture2D blackSheet;

        private static BackgroundSpriteFactory instance = new BackgroundSpriteFactory();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            blackSheet = content.Load<Texture2D>("blackBackground");
        }
      
        public ISprite CreateBlackBackgroundSprite()
        {
            return new BlackBackgroundSprite(blackSheet);
        }
    }
}
