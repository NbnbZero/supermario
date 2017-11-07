using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Items
{
    class UpMushroomSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;

        

        public UpMushroomSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / ItemSpriteFactory.ItemSpriteSheetColumns;
            height = this.Texture.Height / ItemSpriteFactory.ItemSpritesSheetRows;

        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = ItemSpriteFactory.GreenMushroomSpriteRow;
            int column = ItemSpriteFactory.GreenMushromSpriteColumn;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }

    }
}