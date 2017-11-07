using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class RockBlockSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;
        private int row;
        private int column;
        private int totalFrame;
        public RockBlockSprite(Texture2D texture) 
        {
            width = BlockSpriteFactory.Instance.RockBlockWidth;
            height = BlockSpriteFactory.Instance.RockBlockHeight;
            row = BlockSpriteFactory.Instance.RockSpriteSheetRows;
            height = BlockSpriteFactory.Instance.RockSpriteSheetColum;
            totalFrame = BlockSpriteFactory.Instance.RockBlockAnimeTotalFrame;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle= MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public  void Update()
        {            
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width , height);
        }
    }
}
