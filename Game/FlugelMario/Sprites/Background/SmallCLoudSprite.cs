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
    public class SmallCloudSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int smallCloudWidth = 32;
        private int smallCloudHeight = 24;
        private int textureX = 128;
        private int textureY = 11;

        public SmallCloudSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, smallCloudWidth, smallCloudHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, smallCloudWidth, smallCloudHeight);
        }
    }
}
