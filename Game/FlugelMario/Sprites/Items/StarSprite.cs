using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Sprites.Items
{
    class StarSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int StarWtidth = ItemSpriteFactory.Instance.StarWith;
        private int StarHeight = ItemSpriteFactory.Instance.StarHeight;
        private int TextureX = (int)ItemSpriteFactory.Instance.StarAnimation1.X;
        private int TextureY = (int)ItemSpriteFactory.Instance.StarAnimation1.Y;
        private int currentFrame;
        private int TotalFrames = ItemSpriteFactory.Instance.StarAnimeTotalFrame;
        private int counter = 0;

        public StarSprite(Texture2D texture)
        {
            currentFrame = 0;
            this.Texture = texture;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle((TextureX + currentFrame) * StarWtidth, TextureY * StarHeight, StarWtidth, StarHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, StarWtidth, StarHeight);
        }
    }
}
