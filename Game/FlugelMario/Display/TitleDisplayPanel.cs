using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using SuperMario.SCsystem;

namespace SuperMario.DisplayPanel
{
    class TitleDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        public int OptionNum
        {
            get
            {
                return option;
            }
        }
        ISprite titleImg;
        IText highestScoreText;
        IText instructionTextSprite;

        private const int screenHeight = 500;
        private const int scoreLength = 6;
        private const int titleImgY = 130;
        private const int castY = screenHeight / 2 + 50;
        private const int instructionY = screenHeight / 2 + 20;
        private const int highestScoreY = screenHeight / 2 + 40;
        private const int optionMax = 1;
        public int option = 0;
        private const String Level1_1 = "Level 1-1";
        private const String Level2_2 = "Level 2-2";

        public TitleDisplayPanel()
        {

            CoinSystem.Instance.ResetCoin();
            ScoringSystem.ResetScore();
            this.titleImg = BackgroundSpriteFactory.Instance.CreateTitleImgSprite();
            highestScoreText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            highestScoreText.text = "Top Score - " + fixText(" " + MarioInfo.HighestScore, scoreLength);
            instructionTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            instructionTextSprite.text = Level1_1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.Title)
            {
                int titleImgX = Camera.CameraX + Camera.CenterOfScreen - (titleImg.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                titleImg.Draw(spriteBatch, new Vector2(titleImgX, titleImgY));

                int instructionTextX = Camera.CameraX + Camera.CenterOfScreen - (instructionTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                instructionTextSprite.Draw(spriteBatch, new Vector2(instructionTextX, instructionY));

                int highestScoreTextX = Camera.CameraX + Camera.CenterOfScreen - (highestScoreText.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                highestScoreText.Draw(spriteBatch, new Vector2(highestScoreTextX, highestScoreY));
            }
        }

        public void Update()
        {
            highestScoreText.text = "Highest Score - " + fixText(" " + MarioInfo.HighestScore, scoreLength);
            switch (option)
            {
                case 0:
                    instructionTextSprite.text = Level1_1;
                    break;
                case 1:
                    instructionTextSprite.text = Level2_2;
                    break;
                default:
                    break;
            }
        }

        public void Up()
        {
            if (option == 0)
            {
                option = 1;
            }
            else
            {
                option = 0;
            }
        }

        public void Down()
        {
            if (option == 1)
            {
                option = 0;
            }
            else
            {
                option = 1;
            }
        }


        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = "0" + str;
            }

            return str;
        }
    }
}
