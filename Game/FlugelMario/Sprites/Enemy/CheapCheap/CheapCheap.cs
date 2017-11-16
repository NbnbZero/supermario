using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario;

namespace SuperMario.Sprites.CheapCheap
{
    class CheapCheapSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int CheapCheapWidth = EnemySpriteFactory.Instance.CheapCheapWidth;
        private int CheapCheapHeight = EnemySpriteFactory.Instance.CheapCheapHeight;
        private int TextureX = 0;
        private int TextureY = 0;
        private int currentFrame;
        private int TotalFrames = 1;
        private int counter = 0;

        public CheapCheapSprite(Texture2D texture)
        {
            currentFrame = 0;
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle((TextureX + currentFrame) * CheapCheapWidth, TextureY * CheapCheapHeight, CheapCheapWidth, CheapCheapHeight);
            Destination = MakeDestinationRectangle(location);


            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
            if (counter % 10 == 0)
            {
                currentFrame++;
                currentFrame = currentFrame % TotalFrames;
                counter = 0;
            }
            counter++;
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, CheapCheapWidth, CheapCheapHeight);
        }
    }
}
