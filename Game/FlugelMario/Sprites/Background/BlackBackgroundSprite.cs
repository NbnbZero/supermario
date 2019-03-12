using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites.Background
{
    class BlackBackgroundSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int blackBackgroundWidth = 1200;
        private int blackBackgroundHeight = 600;
        private int textureX = 0;
        private int textureY = 0;
        public BlackBackgroundSprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, blackBackgroundWidth, blackBackgroundHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);

        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, blackBackgroundWidth, blackBackgroundHeight);
        }
    }
}
