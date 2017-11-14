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
    class WinningDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        ISprite backgroundSprite;
        IText winningTextSprite;
        IText marioTitleTextSprite;
        ISprite coinSprite;
        ISprite marioSprite;
        IText coinTextSprite;
        IText multiTextSprite;
        IText lifeTextSprite;
        IText timeTitleTextSprite;
        IText timeTextSprite;
        IText scoreTextSprite;
        IText AskForContSprite;
        Game1 game;
        private const int scoreLength = 6;
        private const int coinLength = 2;
        private const int timeLength = 3;
        private const int screenHeight = 500;

        public WinningDisplayPanel(Game1 Game)
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            winningTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            winningTextSprite.text = "Victory";
            AskForContSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            AskForContSprite.text = "Replay? Y / N";
            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.text = "Player1Mario";
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.text = fixText("" + MarioInfo.HighestScore, scoreLength);
            coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.text = "*" + fixText("  " + CoinSystem.Instance.Coins, coinLength);
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.text = "*";
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.text = "" + MarioInfo.MarioLife[0];
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.text = "Time";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.text = fixText("" + MarioInfo.Time, timeLength);
            game = Game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.GameComplete)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera.CameraX, 0));
                int halfOfGameOverTextWidth = winningTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2;
                int winningTextY = screenHeight / 2 - 60;
                winningTextSprite.Draw(spriteBatch, new Vector2(Camera.CameraX + Camera.CenterOfScreen - halfOfGameOverTextWidth, winningTextY));

                int marioTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 2 / 5 - (marioTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, screenHeight / 2 + 40));

                int scoreTextX = Camera.CameraX + (Camera.CenterOfScreen * 2 / 5 - (scoreTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                scoreTextSprite.Draw(spriteBatch, new Vector2(scoreTextX, screenHeight / 2 + 60));

                int coinTextX = Camera.CameraX + (Camera.CenterOfScreen * 4 / 5 - (coinTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                coinTextSprite.Draw(spriteBatch, new Vector2(coinTextX, screenHeight / 2 + 40));

                int coinX = coinTextX - coinSprite.MakeDestinationRectangle(Vector2.Zero).Width + 2;
                int coinY = screenHeight / 2 + 40 - coinSprite.MakeDestinationRectangle(Vector2.Zero).Height / 3;
                coinSprite.Draw(spriteBatch, new Vector2(coinX, coinY));

                int marioX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (marioSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3) - 20);
                marioSprite.Draw(spriteBatch, new Vector2(marioX, screenHeight / 2 + 1));

                int multiTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, screenHeight / 2 + 40));

                int lifeTextX = Camera.CameraX + (Camera.CenterOfScreen * 6 / 5 - (lifeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3) + 10);
                lifeTextSprite.Draw(spriteBatch, new Vector2(lifeTextX, screenHeight / 2 + 40));

                int timeTitleTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, screenHeight / 2 + 40));

                int timeTextX = Camera.CameraX + (Camera.CenterOfScreen * 8 / 5 - (timeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 3));
                timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, screenHeight / 2 + 60));



                int askForContX = Camera.CameraX + Camera.CenterOfScreen - (AskForContSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                AskForContSprite.Draw(spriteBatch, new Vector2(askForContX, winningTextY + 140));
            }

        }

        public void Update()
        {
            if (Game1.State.Type == GameStates.GameComplete)
            {
                MarioInfo.MarioLife[0] = 3;
                MarioInfo.UpdateHighestScore();
                CoinSystem.Instance.ResetCoin();
                ScoringSystem.ResetScore();
                MarioInfo.ClearTimer();

            }
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
