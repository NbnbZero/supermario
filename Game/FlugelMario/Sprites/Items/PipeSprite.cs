using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Sprites.Items
{
    public class PipeSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int width;
        private int height;
        private int heightOffset = 4;

        public PipeSprite(Texture2D texture)
        {
            Texture = texture;
            width = 32;
            height = Texture.Height / PipeSpriteFactory.PipeSpriteSheetRows - heightOffset;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int row = PipeSpriteFactory.PipeSpriteRow;
            int column = PipeSpriteFactory.PipeSpriteColumn;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row + heightOffset, width, height);
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
    }
}
