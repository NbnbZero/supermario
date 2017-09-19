using FlugelMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites
{
    class CrouchRightBigMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private const int MarioWidth = 15;
        private const int MarioHeight = 21;
        private const int TextureX = 179;
        private const int TextureY = 54;

        public CrouchRightBigMarioSprite()
        {
            sourceRectangle = new Rectangle(TextureX, TextureY, MarioWidth, MarioHeight);
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            Rectangle destinationRectangle = new Rectangle((int)marioLocation.X, (int)marioLocation.Y, MarioWidth, MarioHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
