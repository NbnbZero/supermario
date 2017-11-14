using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites.Background
{
    public class BigCloudSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int bigCloudWidth = 64;
        private int bigCloudHeight = 24;
        private int textureX = 208;
        private int textureY = 11;

        public BigCloudSprite(Texture2D texture)
        {

            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, bigCloudWidth, bigCloudHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, bigCloudWidth, bigCloudHeight);
        }
    }
}