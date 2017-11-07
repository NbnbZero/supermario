using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Items;
using SuperMario.SpriteFactories;

namespace SuperMario.Sprites.Blocks
{
    class QuestionBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;
        private int row;
        private int column;
        private int currentFrame;
        private int totalFrame;
        private int spriteFrameIncrement;
        /*public QuestionBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            Height = BlockSpriteFactory.Instance.QuestionBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;

            SetItem(item);
        }
        */
        public QuestionBlockSprite(Texture2D texture)
        {
            Texture = texture;
            height = BlockSpriteFactory.Instance.QuestionBlockHeight;
            width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            row = BlockSpriteFactory.Instance.QuestionSpriteSheetRows;
            column = BlockSpriteFactory.Instance.QuestionSpriteSheetColum;
            totalFrame = BlockSpriteFactory.Instance.RockBlockAnimeTotalFrame;
            currentFrame = 0;
            spriteFrameIncrement = -1;            
        }
        /*public QuestionBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            Height = BlockSpriteFactory.Instance.QuestionBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;

            SetItem(item);
        }*/

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 10)
            {
                currentFrame = 0;
                if (currentFrame == 0 || currentFrame == totalFrame - 1)
                {
                    spriteFrameIncrement *= -1;
                }
                currentFrame += spriteFrameIncrement;
            }            
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
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
