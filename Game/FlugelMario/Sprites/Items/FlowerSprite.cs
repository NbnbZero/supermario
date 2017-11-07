using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Items
{
    class FlowerSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int currentSpriteFrame;
        private int totalSpriteFrame;
        private int spriteFrameIncrement;
        private int currentDrawingFrame;
        private int drawingFrameDelay;
        private int width;
        private int height;

        public FlowerSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / ItemSpriteFactory.ItemSpriteSheetColumns;
            height = this.Texture.Height / ItemSpriteFactory.ItemSpritesSheetRows;

            totalSpriteFrame = ItemSpriteFactory.ItemSpriteSheetColumns;
            currentDrawingFrame = 0;
            drawingFrameDelay = 10;
            currentSpriteFrame = 0;
            spriteFrameIncrement = -1;
        }
        
        public void Update()
        {
            currentDrawingFrame++;
            if (currentDrawingFrame == drawingFrameDelay)
            {
                currentDrawingFrame = 0;
                if (currentSpriteFrame == 0 || currentSpriteFrame == totalSpriteFrame - 1)
                {
                    spriteFrameIncrement *= -1;
                }
                currentSpriteFrame += spriteFrameIncrement;
            }
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = ItemSpriteFactory.FlowerSpriteRow;
            int column = ItemSpriteFactory.FlowerSpriteColumn;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}