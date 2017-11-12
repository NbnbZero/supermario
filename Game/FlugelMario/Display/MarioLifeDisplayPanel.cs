using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.Interfaces;
using SuperMairo.SpriteFactories;
using SuperMario.Sound;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Display
{
    class MarioLifeDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        ISprite backgroundSprite;
        ISprite marioSprite;
        IText worldTextSprite;
        IText multiTextSprite;
        IText lifeTextSprite;
        private int count = 0;
        private const int maxCount = 100;
        private const int screenHeight = 280;
        private const int firstRowY = screenHeight / 2 - 35;
        private const int secRowY = screenHeight / 2 - 10;

        public MarioLifeDisplayPanel()
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.text = "WORLD 1-1";
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.text = "*";
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.text = "" + MarioAttributes.MarioLife[0];
            count = maxCount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.LifeDisplay)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera.CameraX, 0));

                int worldTextX = Camera.CameraX + Camera.CenterOfScreen - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, firstRowY));

                int multiTextX = Camera.CameraX + Camera.CenterOfScreen - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, secRowY));

                int lifeTextX = Camera.CameraX + Camera.CenterOfScreen - (lifeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) + 20;
                lifeTextSprite.Draw(spriteBatch, new Vector2(lifeTextX, secRowY));

                int marioX = Camera.CameraX + Camera.CenterOfScreen - (marioSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) - 20;
                marioSprite.Draw(spriteBatch, new Vector2(marioX, firstRowY));
            }

        }

        public void Update()
        {
            lifeTextSprite.text = "" + MarioAttributes.MarioLife[0];
            if (Game1.State.Type == GameStates.LifeDisplay)
            {
                count--;
                if (count == 0)
                {
                    Game1 game = (Game1)GameData.Game;
                    //game.Reset();
                    Game1.State.Proceed();
                    //SoundManager.Instance.PlayOverWorldSong();
                }
            }
        }
    }
}
