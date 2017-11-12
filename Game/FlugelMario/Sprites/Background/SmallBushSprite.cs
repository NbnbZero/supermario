using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Sprites.Background
{
    public class SmallBushSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int smallBushWidth = 31;
        private int smallBushHeight = 16;
        private int textureX = 273;
        private int textureY = 19;

        public SmallBushSprite(Texture2D texture)
        {

            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, smallBushWidth, smallBushHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, smallBushWidth, smallBushHeight);
        }
    }
}
