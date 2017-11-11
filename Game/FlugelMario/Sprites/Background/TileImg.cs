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
    class TitleImg : ISprite
    {
        public Texture2D Texture { get; set; }
        private int width;
        private int height;
        public TitleImg(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width;
            height = this.Texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, (int)(width / 1.5f), (int)(height / 1.5f));
        }
    }
}
