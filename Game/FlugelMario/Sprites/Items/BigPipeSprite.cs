using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Sprites.Items
{
    class BigPipeSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int bigPipeWidth = 32;
        private int bigPipeHeight = 64;
        private int textureX = 0;
        private int textureY = 0;
        public BigPipeSprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, bigPipeWidth, bigPipeHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, bigPipeWidth, bigPipeHeight);
        }
    }
}
