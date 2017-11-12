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
    public class SmallHillSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Rectangle sourceRectangle;
        private int smallHillWidth = 48;
        private int smallHillHeight = 19;
        private int textureX = 0;
        private int textureY = 16;
        private int displacement = 13;
        public SmallHillSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle(textureX, textureY, smallHillWidth, smallHillHeight);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + displacement, smallHillWidth, smallHillHeight);
        }
    }
}
