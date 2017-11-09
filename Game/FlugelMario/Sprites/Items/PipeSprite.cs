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

        public PipeSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / PipeSpriteFactory.PipeSpriteColumn;
            height = this.Texture.Height / PipeSpriteFactory.PipeSpriteSheetRows;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle( 0, 0, width-4, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
