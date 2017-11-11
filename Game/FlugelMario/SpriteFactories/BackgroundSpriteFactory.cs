using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.Sprites.Background;
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
        private Texture2D backgroundSheet;
        private Texture2D titleSheet;

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
            backgroundSheet = content.Load<Texture2D>("Background");
            titleSheet = content.Load<Texture2D>("TitleImage");
        }
      
        public ISprite CreateBlackBackgroundSprite()
        {
            return new BlackBackgroundSprite(blackSheet);
        }
        public ISprite CreateBackgroundSprite()
        {
            return new BlackBackgroundSprite(backgroundSheet);
        }
        public ISprite CreateTitleImgSprite()
        {
            return new TitleImg(titleSheet);
        }
    }
}
