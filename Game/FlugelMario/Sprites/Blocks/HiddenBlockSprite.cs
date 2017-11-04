using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Blocks
{
    class HiddenBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;
        private int row;
        private int column;
        
        public HiddenBlockSprite(Texture2D texture)
        {
            Texture = texture;
            width = BlockSpriteFactory.Instance.UsedBlockWidth;
            height = BlockSpriteFactory.Instance.UsedBlockHeight;            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = MakeDestinationRectangle(location);


            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.Transparent);

        }
        public void Update()
        {            
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width , height);
        }
    }
}