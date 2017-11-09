using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Items;


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
        private int counter;

        public QuestionBlockSprite(Texture2D texture)
        {
            Texture = texture;
            height = BlockSpriteFactory.Instance.QuestionBlockHeight;
            width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            row = BlockSpriteFactory.Instance.QuestionSpriteSheetRows;
            column = BlockSpriteFactory.Instance.QuestionSpriteSheetColum;
            totalFrame = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;
            currentFrame = 0;
            counter = 0;
            spriteFrameIncrement = -1;            
        }

        public void Update()
        {
            if (counter % 10 == 0)
            {
                currentFrame++;
                currentFrame = currentFrame % totalFrame;
                counter = 0;
            }
            counter++;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle((currentFrame*width), 0, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
