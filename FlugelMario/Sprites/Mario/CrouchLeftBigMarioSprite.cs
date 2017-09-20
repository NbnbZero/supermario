using FlugelMario.AbstractClasses;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites
{
    class CrouchLeftBigMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.CrouchLeftBigMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.CrouchLeftBigMarioCord.Y;

        public CrouchLeftBigMarioSprite(Texture2D texture) : base(texture)
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