using FlugelMario.AbstractClasses;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Mario
{
    class JumpLeftSmallMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.JumpLeftSmallMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.JumpLeftSmallMarioCord.Y;

        public JumpLeftSmallMarioSprite(Texture2D texture) : base(texture)
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
