using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class SeaWeedSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;
        private int row;
        private int column;
        public SeaWeedSprite(Texture2D texture)
        {
            Texture = texture;
            width = BlockSpriteFactory.Instance.SeaWeedWidth;
            height = BlockSpriteFactory.Instance.SeaWeedHeight;
            row = BlockSpriteFactory.Instance.SeaweedSpriteRows;
            column = BlockSpriteFactory.Instance.SeaweedSpriteRows;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
