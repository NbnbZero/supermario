using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class MarioStarSprite : MarioSprite
    {
        protected int currentFlashingFrame;
        protected int totalFlashingFrame = MarioSpriteFactory.Instance.StarMarioSpriteSheetRow / 2;
        protected int currentFlashingDrawingFrame;
        protected int flashingDrawingFrameDelay = 3;
        protected int baseFrame = 0;

        public MarioStarSprite(Texture2D texture) : base(texture)
        {
            currentFlashingDrawingFrame = baseFrame;
        }

        public override void Update()
        {
            currentFlashingDrawingFrame++;
            if (currentFlashingDrawingFrame == flashingDrawingFrameDelay)
            {
                currentFlashingDrawingFrame = baseFrame;
                currentFlashingFrame++;
                if (currentFlashingFrame == totalFlashingFrame)
                {
                    currentFlashingFrame = baseFrame;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
