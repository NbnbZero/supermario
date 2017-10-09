using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites
{
    class IdleRightSmallMarioSprite : MarioSprite
    {
        public IdleRightSmallMarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            TextureX = (int)MarioSpriteFactory.Instance.IdleRightSmallMarioCord.X;
            TextureY = (int)MarioSpriteFactory.Instance.IdleRightSmallMarioCord.Y;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = TextureX * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
