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
    public class MediumPipeSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int mediumPipeWidth = 32;
        private int mediumPipeHeight = 48;
        private int textureX = 41;
        private int textureY = 16;
        public MediumPipeSprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, mediumPipeWidth, mediumPipeHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, mediumPipeWidth, mediumPipeHeight);
        }
    }
}
