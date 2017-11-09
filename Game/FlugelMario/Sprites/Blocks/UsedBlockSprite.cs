using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class UsedBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        protected int width;
        protected int height;
        protected int row;
        protected int column;

        public UsedBlockSprite(Texture2D texture)
        {
            Texture = texture;
            width = BlockSpriteFactory.Instance.UsedBlockWidth;
            height = BlockSpriteFactory.Instance.UsedBlockHeight;

        }
        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            width = BlockSpriteFactory.Instance.UsedBlockWidth;
            height = BlockSpriteFactory.Instance.UsedBlockHeight;
            row = BlockSpriteFactory.Instance.UsedSpriteSheetRows;
            column = BlockSpriteFactory.Instance.UsedSpriteSheetColum;
        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width , height);
        }
    }
}
