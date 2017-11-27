using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMario.Sprites.Mario
{
    class SwimmingRightFireMarioSprite : BigMarioSwimmingSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.SwimmingRightFireMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.SwimmingRightFireMarioCord.Y;
        public SwimmingRightFireMarioSprite(Texture2D texture) : base(texture)
        {
            CurrentSwimmingFrame = 0;
            SwimmingFrameIncrement = -1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX + CurrentSwimmingFrame) * bigSwimMarioWidth;
            int y = TextureY * bigSwimMarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }

    }
}
