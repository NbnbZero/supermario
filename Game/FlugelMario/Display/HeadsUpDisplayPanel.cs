using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.HeadsUp;
using SuperMairo.Interfaces;
using SuperMairo.SpriteFactories;
using SuperMario.Heads_Up;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Display
{
    class HeadsUpDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; } = true;
        IText marioTitleTextSprite;
        ISprite coinSprite;
        ISprite marioSprite;
        IText coinTextSprite;
        IText multiTextSprite;
        IText lifeTextSprite;
        IText timeTitleTextSprite;
        IText timeTextSprite;
        IText scoreTextSprite;
        private const int marioRow = 1;
        private const int FirstRow = 20;
        private const int SecondRow = 40;
        private const int scoreLength = 6;
        private const int coinLength = 2;
        private const int timeLength = 3;

        public HeadsUpDisplayPanel()
        {
            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.text = "Player1Mario";
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.text = fixText("" + ScoringSystem.Score, scoreLength);
            coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.text = "*" + fixText("  " + CoinSystem.Instance.Coins, coinLength);
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.text = "*";
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.text = "" + MarioAttributes.MarioLife[0];
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.text = "Time";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.text = fixText("" + MarioAttributes.Time, timeLength);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int marioTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 2 / 5 - (marioTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, -Camera.CameraY+FirstRow));

            int scoreTextX = Camera.CameraX + (Camera.CenterOfScreen * 2 / 5 - (scoreTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            scoreTextSprite.Draw(spriteBatch, new Vector2(scoreTextX, -Camera.CameraY+SecondRow));

            int coinTextX = Camera.CameraX + (Camera.CenterOfScreen * 4 / 5 - (coinTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            coinTextSprite.Draw(spriteBatch, new Vector2(coinTextX, -Camera.CameraY+FirstRow));

            int coinX = coinTextX - coinSprite.MakeDestinationRectangle(Vector2.Zero).Width + 2;
            int coinY = -Camera.CameraY+FirstRow - coinSprite.MakeDestinationRectangle(Vector2.Zero).Height / 3;
            coinSprite.Draw(spriteBatch, new Vector2(coinX, coinY));

            int marioX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (marioSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3)-20);
            marioSprite.Draw(spriteBatch, new Vector2(marioX, -Camera.CameraY + marioRow));

            int multiTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, -Camera.CameraY+FirstRow));

            int lifeTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (lifeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3) + 10);
            lifeTextSprite.Draw(spriteBatch, new Vector2(lifeTextX, -Camera.CameraY+FirstRow));

            int timeTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, -Camera.CameraY+FirstRow));

            int timeTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, -Camera.CameraY+SecondRow));
        }

        public void Update()
        {
            coinSprite.Update();
            coinTextSprite.text = "*" + fixText("" + CoinSystem.Instance.Coins, coinLength);
            timeTextSprite.text = fixText("" + MarioAttributes.Time, timeLength);
            lifeTextSprite.text = "" + MarioAttributes.MarioLife[0];
            scoreTextSprite.text = fixText("" + ScoringSystem.Score, scoreLength);
        }

        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = 0 + str;
            }

            return str;
        }
    }
}
