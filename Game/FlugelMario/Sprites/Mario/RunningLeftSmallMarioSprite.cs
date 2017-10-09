using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Mario
{
    class RunningLeftSmallMarioSprite : MarioRunningSprite
    {
        public RunningLeftSmallMarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            TextureX = (int)MarioSpriteFactory.Instance.RunningLeftSmallMarioCord.X;
            TextureY = (int)MarioSpriteFactory.Instance.RunningLeftSmallMarioCord.Y;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - CurrentRunningFrame) * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
