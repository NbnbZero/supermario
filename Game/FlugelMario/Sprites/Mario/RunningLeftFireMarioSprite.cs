using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Mario
{
    class RunningLeftFireMarioSprite : MarioRunningSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.RunningLeftFireMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.RunningLeftFireMarioCord.Y;
        public RunningLeftFireMarioSprite(Texture2D texture) : base(texture)
        {
            currentRunningFrame = totalRunningFrame - 1;
            runningFrameIncrement = 1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - currentRunningFrame) * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
