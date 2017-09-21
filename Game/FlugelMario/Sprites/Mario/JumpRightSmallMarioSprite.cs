using FlugelMario.AbstractClasses;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Mario
{
    class JumpRightSmallMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.JumpRightSmallMarioCord.Y;

        public JumpRightSmallMarioSprite(Texture2D texture) : base(texture)
        {
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
