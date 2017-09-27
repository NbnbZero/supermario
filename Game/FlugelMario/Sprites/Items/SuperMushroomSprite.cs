using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites.Items
{
    class SuperMushroomSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int SuperMushroomWtidth = ItemSpriteFactory.Instance.SuperMushroomWith;
        private int SuperMushroomHeight = ItemSpriteFactory.Instance.SuperMushroomHeight;
        private int TextureX = (int)ItemSpriteFactory.Instance.SuperMushroomAnimation1.X;
        private int TextureY = (int)ItemSpriteFactory.Instance.SuperMushroomAnimation1.Y;
        private int currentFrame;
        private int TotalFrames = ItemSpriteFactory.Instance.SuperMushroomAnimeTotalFrame;
        private int counter = 0;

        public SuperMushroomSprite(Texture2D texture)
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
            sourceRectangle = new Rectangle((TextureX + currentFrame) * SuperMushroomWtidth, TextureY * SuperMushroomHeight, SuperMushroomWtidth, SuperMushroomHeight);
            Destination = MakeDestinationRectangle(location);

            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, SuperMushroomWtidth, SuperMushroomHeight);
        }
    }
}
