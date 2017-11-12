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
        IText AskForContSprite;
        Game1 game;
        private const int screenHeight = 500;

        public GameOverDisplayPanel(Game1 Game)
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            gameOverTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            gameOverTextSprite.text = "GAME OVER";
            AskForContSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            AskForContSprite.text = "Continue? Y / N";
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
                int askForContX = Camera.CameraX + Camera.CenterOfScreen - (AskForContSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                AskForContSprite.Draw(spriteBatch, new Vector2(askForContX, gameOverTextY + 50));
            }

        }

        public void Update()
        {
            if (Game1.State.Type == GameStates.GameOver)
            {
                
                    MarioAttributes.MarioLife[0] = 3;
                    MarioAttributes.UpdateHighestScore();
                    CoinSystem.Instance.ResetCoin();
                    ScoringSystem.ResetScore();
                    MarioAttributes.ClearTimer();
                
            }
        }
    }
}
