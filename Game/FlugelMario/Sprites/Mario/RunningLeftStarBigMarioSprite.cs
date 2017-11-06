using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites
{
    class RunningLeftStarBigMarioSprite : MarioRunningStarSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.RunningLeftStarBigMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.RunningLeftStarBigMarioCord.Y;
        public RunningLeftStarBigMarioSprite(Texture2D texture) : base(texture)
        {
            CurrentRunningFrame = TotalRunningFrame - 1;
            RunningFrameIncrement = 1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - CurrentRunningFrame) * MarioWidth;
            int y = (TextureY + currentFlashingFrame) * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
