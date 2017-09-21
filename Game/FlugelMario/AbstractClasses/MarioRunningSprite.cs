using FlugelMario.AbstractClasses;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Mario
{
   public abstract class MarioRunningSprite : MarioSprite
    {
        protected int currentRunningFrame;
        protected int totalRunningFrame = MarioSpriteFactory.Instance.NormalMarioSpriteRunningSheetColumn;
        protected int runningFrameIncrement;
        protected int currentRunningDrawingFrame;
        private int runningDrawingFrameDelay = 5;
        private int baseFrame = 0;

        public MarioRunningSprite(Texture2D texture) : base(texture)
        {
            currentRunningDrawingFrame = baseFrame;
        }

        public override void Update()
        {
            currentRunningDrawingFrame++;
            if (currentRunningDrawingFrame == runningDrawingFrameDelay)
            {
                currentRunningDrawingFrame = baseFrame;
                if (currentRunningFrame == baseFrame || currentRunningFrame == totalRunningFrame - 1)
                {
                    runningFrameIncrement *= -1;
                }
                currentRunningFrame += runningFrameIncrement;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            base.Draw(spriteBatch, location);
        }
    }
}
