using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMario.Sprites
{
    class IdleLeftFireMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.IdleLeftFireMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.IdleLeftFireMarioCord.Y;
        public IdleLeftFireMarioSprite(Texture2D texture) : base(texture)
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
