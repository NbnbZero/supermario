using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.SCsystem;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Display
{
    class ConversationDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        IText ConversationTextSprite;
        private const int screenHeight = 500;

        public ConversationDisplayPanel()
        {
            ConversationTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            ConversationTextSprite.text = "YOU DID IT!";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int halfOfGameOverTextWidth = ConversationTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2;
            int gameOverTextY = screenHeight / 2 - 60;
            ConversationTextSprite.Draw(spriteBatch, new Vector2(Camera.CameraX + Camera.CenterOfScreen - halfOfGameOverTextWidth, -Camera.CameraY + gameOverTextY));
        }

        public void Update()
        {
            
        }
    }
}
