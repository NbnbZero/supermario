using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Mario
{
    class RunningRightFireMarioSprite : MarioRunningSprite
    {
        public RunningRightFireMarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = MarioSpriteFactory.Instance.BigMarioWidth;
            Height = MarioSpriteFactory.Instance.BigMarioHeight;
            TextureX = (int)MarioSpriteFactory.Instance.RunningRightFireMarioCord.X;
            TextureY = (int)MarioSpriteFactory.Instance.RunningRightFireMarioCord.Y;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - CurrentRunningFrame) * BigMarioWidth;
            int y = TextureY * BigMarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
