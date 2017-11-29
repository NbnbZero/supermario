using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Goomba
{
    class BlooperCloseSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int BlooperWidth = EnemySpriteFactory.Instance.BlooperWidth;
        private int BlooperHeight = EnemySpriteFactory.Instance.BlooperHeight;
        private int TextureX = 0;
        private int TextureY = 0;

        public BlooperCloseSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle(TextureX * BlooperWidth, TextureY * BlooperHeight, BlooperWidth, BlooperHeight);
            Destination = new Rectangle((int)location.X, (int)location.Y, BlooperWidth, BlooperHeight);

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, BlooperWidth, BlooperHeight);
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
        }
    }
}
