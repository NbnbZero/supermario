using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sprites.Items;

namespace SuperMario.Sprites.Blocks
{
    class BrickBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;
        private int row;
        private int column;

        public BrickBlockSprite(Texture2D texture)
        {
            Texture = texture;
            width = BlockSpriteFactory.Instance.BrickBlockWidth;
            height = BlockSpriteFactory.Instance.BrickBlockHeight;
            int row = BlockSpriteFactory.Instance.BrickSpriteSheetRows;
            int column = BlockSpriteFactory.Instance.BrickSpriteSheetColum;
        }

        /*public BrickBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {

            TextureX = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.Y;
            
            TotalFrames = BlockSpriteFactory.Instance.BrickBlockAnimeTotalFrame;

            //SetItem(item);
        }*/

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {            
            Rectangle sourceRectangle = new Rectangle(width*column,height*row,width,height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);            
        }

        public void Update()
        {
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        /*public override void RespondToCollision(CollisionDirection direction)
        {
            if (direction == CollisionDirection.Bottom)
            {
                BumpUp();
                //Animate();
                GetItem().Reveal();
            }
        }*/
    }
}
