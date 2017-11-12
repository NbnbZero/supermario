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
    class GameOverDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        ISprite backgroundSprite;
        IText gameOverTextSprite;
        Game1 game;
        private int count = 0;
        private const int maxCount = 200;
        private const int screenHeight = 500;

        public GameOverDisplayPanel(Game1 Game)
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            gameOverTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            gameOverTextSprite.text = "GAME OVER";
            count = maxCount;
            game = Game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.GameOver)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera.CameraX, 0));
                int halfOfGameOverTextWidth = gameOverTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2;
                int gameOverTextY = screenHeight / 2 - 30;
                gameOverTextSprite.Draw(spriteBatch, new Vector2(Camera.CameraX + Camera.CenterOfScreen - halfOfGameOverTextWidth, gameOverTextY));
            }

        }

        public void Update()
        {
            if (Game1.State.Type == GameStates.GameOver)
            {
                count--;
                if (count == 0)
                {
                    game.Reset();
                    Game1.State.Proceed();
                    MarioAttributes.MarioLife[0] = 3;
                    MarioAttributes.UpdateHighestScore();
                    CoinSystem.Instance.ResetCoin();
                    ScoringSystem.ResetScore();
                    MarioAttributes.ClearTimer();
                }
            }
        }
    }
}
