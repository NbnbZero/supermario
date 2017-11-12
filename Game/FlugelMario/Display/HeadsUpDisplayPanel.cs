using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        IText coinTextSprite;
        IText worldTitleTextSprite;
        IText worldTextSprite;
        IText timeTitleTextSprite;
        IText timeTextSprite;
        private const int distanceOfFirstRowText = 20;
        private const int distanceOfSecondRowText = 40;

        private const int coinLength = 2;
        private const int timeLength = 3;

        public HeadsUpDisplayPanel()
        {
            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.text = "Mario: " + MarioAttributes.MarioLife[0].ToString();
            
            coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.text = "*" + fixText("" + CoinSystem.Instance.Coins, coinLength);
            worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTitleTextSprite.text = "WORLD";
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.text = "1-1";
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.text = "Time";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.text = fixText("" + MarioAttributes.Time, timeLength);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int marioTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 2 / 5 - (marioTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, distanceOfFirstRowText));

            int coinTextX = Camera.CameraX + (Camera.CenterOfScreen * 4 / 5 - (coinTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            coinTextSprite.Draw(spriteBatch, new Vector2(coinTextX, distanceOfFirstRowText));

            int coinX = coinTextX - coinSprite.MakeDestinationRectangle(Vector2.Zero).Width + 2;
            int coinY = distanceOfFirstRowText - coinSprite.MakeDestinationRectangle(Vector2.Zero).Height / 3;
            coinSprite.Draw(spriteBatch, new Vector2(coinX, coinY));

            int worldTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (worldTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            worldTitleTextSprite.Draw(spriteBatch, new Vector2(worldTitleTextX, distanceOfFirstRowText));

            int worldTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, distanceOfSecondRowText));

            int timeTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, distanceOfFirstRowText));

            int timeTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
            timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, distanceOfSecondRowText));
        }

        public void Update()
        {
            coinSprite.Update();
            coinTextSprite.text = "*" + fixText("" + CoinSystem.Instance.Coins, coinLength);
            timeTextSprite.text = fixText("" + MarioAttributes.Time, timeLength);
            marioTitleTextSprite.text = "Mario: " + MarioAttributes.MarioLife[0].ToString();
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
