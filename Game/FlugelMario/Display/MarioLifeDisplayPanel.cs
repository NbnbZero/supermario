using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using SuperMario.SCsystem;
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
        IText AskForContSprite;
        private const int screenHeight = 500;
        private const int firstRowY = screenHeight / 2 - 60 ;
        private const int marioRowY = screenHeight / 2 - 50;
        private const int secRowY = screenHeight / 2 -30;
        private const int thirdRowY = screenHeight / 2;
        public MarioLifeDisplayPanel(IMario mario)
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();

            if (mario.IsLevel2)
            {
                worldTextSprite.text = "WORLD 2-2";
            }
            else
            {
                worldTextSprite.text = "WORLD 1-1";
            }          
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.text = "*";
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.text = "" + MarioInfo.MarioLife[0];
            AskForContSprite= TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            AskForContSprite.text = "Continue? Y / N";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.State.Type == GameStates.LifeDisplay)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera.CameraX, -Camera.CameraY));

                int worldTextX = Camera.CameraX + Camera.CenterOfScreen - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, -Camera.CameraY+firstRowY));

                int multiTextX = Camera.CameraX + Camera.CenterOfScreen - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, -Camera.CameraY+secRowY));

                int lifeTextX = Camera.CameraX + Camera.CenterOfScreen - (lifeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) + 20;
                lifeTextSprite.Draw(spriteBatch, new Vector2(lifeTextX, -Camera.CameraY+secRowY));

                int marioX = Camera.CameraX + Camera.CenterOfScreen - (marioSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) - 20;
                marioSprite.Draw(spriteBatch, new Vector2(marioX, -Camera.CameraY+marioRowY));

                int askForContX = Camera.CameraX + Camera.CenterOfScreen - (AskForContSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                AskForContSprite.Draw(spriteBatch, new Vector2(askForContX, -Camera.CameraY+thirdRowY));
            }

        }

        public void Update()
        {
            if (Game1.State.Type == GameStates.LifeDisplay)
            {
                if (MarioInfo.MarioLife[0] > 0)
                {
                    lifeTextSprite.text = "" + MarioInfo.MarioLife[0];
                }
            }
        }
    }
}
