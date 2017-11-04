using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.SpriteFactories;

namespace SuperMario.Sprites.Blocks
{
    class UsedBlockSprite : ISprite
    {
        /*public UsedBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.UsedBlockWidth;
            Height = BlockSpriteFactory.Instance.UsedBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.UsedBlockAnimeTotalFrame;

            SetItem(item);
        }
        */
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
