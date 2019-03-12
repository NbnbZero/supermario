using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Items
{
    class CoinSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int totalSpriteFrame;
        private int currentDrawingFrame;
        private int width;
        private int height;
        private int counter;
        

        public CoinSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / 4;
            height = this.Texture.Height;
            totalSpriteFrame = 4;
            counter = 0;
            currentDrawingFrame = 0;
        }

        public void Update()
        {
            if (counter % 10 == 0)
            {
                currentDrawingFrame++;
                currentDrawingFrame = currentDrawingFrame % totalSpriteFrame;
                counter = 0;
            }
            counter++;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle((currentDrawingFrame * width), 0, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y,width,height);
        }
    }
}