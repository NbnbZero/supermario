using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Sprites.Blocks
{
    class UsedBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int UsedBlockWtidth = BlockSpriteFactory.Instance.UsedBlockWidth;
        private int UsedBlockHeight = BlockSpriteFactory.Instance.UsedBlockHeight;
        private int TextureX = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.X;
        private int TextureY = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.Y;
        private int currentFrame;
        private int TotalFrames = BlockSpriteFactory.Instance.UsedBlockAnimeTotalFrame;
        private int counter = 0;

        public UsedBlockSprite(Texture2D texture)
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
            sourceRectangle = new Rectangle((TextureX + currentFrame) * UsedBlockWtidth, TextureY * UsedBlockHeight, UsedBlockWtidth, UsedBlockHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, UsedBlockWtidth, UsedBlockHeight);
        }
    }
}
