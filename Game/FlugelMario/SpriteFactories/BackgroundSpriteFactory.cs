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
        private Texture2D castleSheet;

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
            titleSheet = content.Load<Texture2D>("TitleImage");
            castleSheet = content.Load<Texture2D>("castle");
            backgroundSheet = content.Load<Texture2D>("outside_scenery");
        }
        public ISprite CreateSmallHillSprite()
        {
            return new SmallHillSprite(backgroundSheet);
        }
        public ISprite CreateBigHillSprite()
        {
            return new BigHillSprite(backgroundSheet);
        }

        public ISprite CreateSmallCloudSprite()
        {
            return new SmallCloudSprite(backgroundSheet);
        }
        public ISprite CreateMediumCloudSprite()
        {
            return new MediumCloudSprite(backgroundSheet);
        }
        public ISprite CreateBigCloudSprite()
        {
            return new BigCloudSprite(backgroundSheet);
        }
        public ISprite CreateSmallBushSprite()
        {
            return new SmallBushSprite(backgroundSheet);
        }
        public ISprite CreateMediumBushSprite()
        {
            return new MediumBushSprite(backgroundSheet);
        }
        public ISprite CreateBigBushSprite()
        {
            return new BigBushSprite(backgroundSheet);
        }
        public ISprite CreateBlackBackgroundSprite()
        {
            return new BlackBackgroundSprite(blackSheet);
        }
        public ISprite CreateTitleImgSprite()
        {
            return new TitleImg(titleSheet);
        }
        public ISprite CreateCastleSprite()
        {
            return new CastleSprite(castleSheet);
        }
    }
}
