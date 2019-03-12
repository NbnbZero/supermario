using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Mario
{
    class RunningRightBigMarioSprite : MarioRunningSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.RunningRightBigMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.RunningRightBigMarioCord.Y;
        public RunningRightBigMarioSprite(Texture2D texture) : base(texture)
        {
            CurrentRunningFrame = 0;
            RunningFrameIncrement = -1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX + CurrentRunningFrame) * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
