using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Mario
{
    class JumpRightSmallMarioSprite : MarioSprite
    {
        public JumpRightSmallMarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            TextureX = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.X;
            TextureY = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.Y;
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
