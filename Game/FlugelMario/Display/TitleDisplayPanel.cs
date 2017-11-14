using SuperMairo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.SpriteFactories;
using SuperMairo.SpriteFactories;
using Microsoft.Xna.Framework;
using SuperMario.Heads_Up;
using SuperMairo.HeadsUp;

namespace SuperMairo.DisplayPanel
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
        IText instructionText;
        IText highestScoreText;

        private const int screenHeight = 500;
        private const int scoreLength = 6;
        private const int titleImgY = 130;
        private const int castY = screenHeight / 2 + 50;
        private const int instructionY = screenHeight / 2 + 20;
        private const int highestScoreY = screenHeight / 2 + 40;
        private const int optionMax = 2;
        private int option = 0;
        private const String pressEnter = "Press Enter to Start";

        public TitleDisplayPanel()
        {
            this.titleImg = BackgroundSpriteFactory.Instance.CreateTitleImgSprite();
            instructionText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            instructionText.text = pressEnter;
            highestScoreText = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            highestScoreText.text = "Top Score - " + fixText(" " + MarioInfo.HighestScore, scoreLength);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.Title)
            {
                int titleImgX = Camera.CameraX + Camera.CenterOfScreen - (titleImg.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                titleImg.Draw(spriteBatch, new Vector2(titleImgX, titleImgY));

                int instructionTextX = Camera.CameraX + Camera.CenterOfScreen - (instructionText.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                instructionText.Draw(spriteBatch, new Vector2(instructionTextX, instructionY));

                int highestScoreTextX = Camera.CameraX + Camera.CenterOfScreen - (highestScoreText.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                highestScoreText.Draw(spriteBatch, new Vector2(highestScoreTextX, highestScoreY));
            }
        }

        public void Update()
        {
            highestScoreText.text = "Highest Score - " + fixText(" " + MarioInfo.HighestScore, scoreLength);
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
